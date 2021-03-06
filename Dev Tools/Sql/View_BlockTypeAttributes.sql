/* BlockType attribute names */
SELECT [bt].[Name] as [BlockTypeName]
      ,[a].[Key]
      ,[ft].[Name] as [FieldType]
      ,[a].[Category]
      ,[a].[Description]
FROM [coreAttribute] [a]
join [coreEntityType] [e] on [e].[Id] = [a].[EntityTypeId]
join [cmsBlockType] [bt] on [bt].[Id] = [a].[EntityTypeQualifierValue]
join [coreFieldType] [ft] on [ft].[Id] = [a].[FieldTypeId]
where [e].[Name] = 'Rock.Cms.Block'
order by [BlockTypeName]



