﻿//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;

namespace Rock.Extension
{
    /// <summary>
    /// Singleton generic class that uses MEF to load and cache all of the component classes
    /// </summary>
    public abstract class Container<T, TData> : IContainer, IDisposable
        where T : IComponent
        where TData : IComponentData
    {
        // MEF Container
        private CompositionContainer container;
        private bool IsDisposed;

        /// <summary>
        /// Gets the componentss.
        /// </summary>
        public Dictionary<int, Lazy<T, TData>> Components { get; private set; }

        /// <summary>
        /// Gets the component names and their attributes
        /// </summary>
        public Dictionary<int, KeyValuePair<string, IComponent>> Dictionary
        {
            get
            {
                var dictionary = new Dictionary<int, KeyValuePair<string, IComponent>>();
                foreach ( var component in Components )
                {
                    dictionary.Add( component.Key, new KeyValuePair<string, IComponent>(
                        component.Value.Metadata.ComponentName, component.Value.Value ) );
                }

                return dictionary;
            }
        }

        /// <summary>
        /// Gets or sets the components.
        /// </summary>
        /// <value>
        /// The components.
        /// </value>
        protected abstract IEnumerable<Lazy<T, TData>> MEFComponents { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Container()
        {
            IsDisposed = false;
        }

        /// <summary>
        /// Forces a reloading of all the GeocodeService classes
        /// </summary>
        public void Refresh()
        {
            Components = new Dictionary<int, Lazy<T, TData>>();

            // Create the MEF Catalog
            var catalog = new AggregateCatalog();

            // Add the currently running assembly to the Catalog
            catalog.Catalogs.Add( new AssemblyCatalog( this.GetType().Assembly ) );

            // Add all the assemblies in the 'Plugins' subdirectory
            string pluginsFolder = Path.Combine( AppDomain.CurrentDomain.BaseDirectory, "Plugins" );
            if ( Directory.Exists( pluginsFolder ) )
            {
                catalog.Catalogs.Add( new DirectoryCatalog( pluginsFolder ) );
            }

            // Create the container from the catalog
            container = new CompositionContainer( catalog );

            // Compose the MEF container with any classes that export the same definition
            container.ComposeParts( this );

            // Add each class found through MEF into the Services property value in the correct order
            int id = 0;
            foreach ( Lazy<T, TData> component in MEFComponents )
            {
                Components.Add( id++, component );
            }
        }

        /// <summary>
        /// Dispose object
        /// </summary>
        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose( bool disposing )
        {
            if ( !IsDisposed )
            {
                if ( disposing )
                {
                    if ( container != null )
                        container.Dispose();
                }

                container = null;
                IsDisposed = true;
            }
        }
    }
}