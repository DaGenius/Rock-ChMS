/* List each Entity's Attributes' Values and which Entity ID it is associated with */
SELECT isnull([e].[Name], 'Global') [EntityName],
       [a].[Key] [AttributeKey],
       [a].[EntityTypeQualifierColumn],
       [a].[EntityTypeQualifierValue],
       isnull(cast([v].[EntityId] as nvarchar(100)), 'n/a') [Entity's Id Value],
       [v].[Id] [AttributeValueId],
       [v].[Value] [Value]
  FROM [coreAttributeValue] [v]
  join [coreAttribute] [a] on [a].[Id] = [v].[AttributeId]
  left join [coreEntityType] [e] on [e].[Id] = [a].[EntityTypeId]
  join [coreFieldType] [ft] on [ft].[Id] = [a].[FieldTypeId]
  order by [EntityName], [AttributeKey]


