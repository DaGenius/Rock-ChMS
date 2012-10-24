//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace Rock.Web.Cache
{
    /// <summary>
    /// Information about a definedValue that is required by the rendering engine.
    /// This information will be cached by the engine
    /// </summary>
    [Serializable]
    public class DefinedValueCache : Rock.Core.DefinedValueDto, Rock.Attribute.IHasAttributes
    {
        private DefinedValueCache() : base() { }
        private DefinedValueCache( Rock.Core.DefinedValue model ) : base( model ) { }

        /// <summary>
        /// Gets the type of the field.
        /// </summary>
        /// <value>
        /// The type of the field.
        /// </value>
        public DefinedTypeCache DefinedType
        {
            get { return DefinedTypeCache.Read( DefinedTypeId ); }
        }

        /// <summary>
        /// Dictionary of categorized attributes.  Key is the category name, and Value is list of attributes in the category
        /// </summary>
        /// <value>
        /// The attribute categories.
        /// </value>
        public SortedDictionary<string, List<string>> AttributeCategories
        {
            get
            {
                var attributeCategories = new SortedDictionary<string, List<string>>();

                foreach ( int id in AttributeIds )
                {
                    var attribute = AttributeCache.Read( id );
                    if ( !attributeCategories.ContainsKey( attribute.Key ) )
                        attributeCategories.Add( attribute.Category, new List<string>() );
                    attributeCategories[attribute.Category].Add( attribute.Key );
                }

                return attributeCategories;
            }

            set { }
        }

        /// <summary>
        /// List of attributes associated with the page.  This object will not include values.
        /// To get values associated with the current page instance, use the AttributeValues
        /// </summary>
        public Dictionary<string, Rock.Web.Cache.AttributeCache> Attributes
        {
            get
            {
                var attributes = new Dictionary<string, Rock.Web.Cache.AttributeCache>();

                foreach ( int id in AttributeIds )
                {
                    Rock.Web.Cache.AttributeCache attribute = AttributeCache.Read( id );
                    attributes.Add( attribute.Key, attribute );
                }

                return attributes;
            }

            set
            {
                this.AttributeIds = new List<int>();
                foreach ( var attribute in value )
                    this.AttributeIds.Add( attribute.Value.Id );
            }
        }

        private List<int> AttributeIds = new List<int>();

        /// <summary>
        /// Dictionary of all attributes and their value.
        /// </summary>
        public Dictionary<string, List<Rock.Core.AttributeValueDto>> AttributeValues { get; set; }

        #region Static Methods

        private static string CacheKey( int id )
        {
            return string.Format( "Rock:DefinedValue:{0}", id );
        }

        /// <summary>
        /// Returns DefinedValue object from cache.  If definedValue does not already exist in cache, it
        /// will be read and added to cache
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DefinedValueCache Read( int id )
        {
            string cacheKey = DefinedValueCache.CacheKey( id );

            ObjectCache cache = MemoryCache.Default;
            DefinedValueCache definedValue = cache[cacheKey] as DefinedValueCache;

            if ( definedValue != null )
                return definedValue;
            else
            {
                Rock.Core.DefinedValueService definedValueService = new Rock.Core.DefinedValueService();
                Rock.Core.DefinedValue definedValueModel = definedValueService.Get( id );
                if ( definedValueModel != null )
                {
                    Rock.Attribute.Helper.LoadAttributes( definedValueModel );

                    definedValue = CopyModel( definedValueModel );

                    cache.Set( cacheKey, definedValue, new CacheItemPolicy() );

                    return definedValue;
                }
                else
                    return null;
            }
        }

        /// <summary>
        /// Reads the specified defined value model.
        /// </summary>
        /// <param name="definedValueModel">The defined value model.</param>
        /// <returns></returns>
        public static DefinedValueCache Read( Rock.Core.DefinedValue definedValueModel )
        {
            string cacheKey = DefinedValueCache.CacheKey( definedValueModel.Id );

            ObjectCache cache = MemoryCache.Default;
            DefinedValueCache definedValue = cache[cacheKey] as DefinedValueCache;

            if ( definedValue != null )
                return definedValue;
            else
            {
                definedValue = DefinedValueCache.CopyModel( definedValueModel );
                cache.Set( cacheKey, definedValue, new CacheItemPolicy() );

                return definedValue;
            }
        }

        /// <summary>
        /// Copies the model.
        /// </summary>
        /// <param name="definedValueModel">The defined value model.</param>
        /// <returns></returns>
        public static DefinedValueCache CopyModel( Rock.Core.DefinedValue definedValueModel )
        {
            DefinedValueCache definedValue = new DefinedValueCache( definedValueModel );

            definedValue.AttributeValues = definedValueModel.AttributeValues;
            definedValue.AttributeIds = new List<int>();

            if ( definedValueModel.Attributes != null )
            {
                foreach ( var attribute in definedValueModel.Attributes )
                {
                    definedValue.AttributeIds.Add( attribute.Value.Id );
                }
            }

            return definedValue;
        }

        /// <summary>
        /// Removes definedValue from cache
        /// </summary>
        /// <param name="id"></param>
        public static void Flush( int id )
        {
            ObjectCache cache = MemoryCache.Default;
            cache.Remove( DefinedValueCache.CacheKey( id ) );
        }

        #endregion
    }
}