/* List DefinedTypeValues*/
SELECT
    t.Category, 
    t.Name as [DefinedType.Name],
    v.Name as Value, 
    v.Description,
    t.Guid [DefinedType.Guid],
    v.Guid [DefinedValue.Guid]
FROM            
    coreDefinedValue AS v 
INNER JOIN
    coreDefinedType AS t ON t.Id = v.DefinedTypeId
ORDER BY t.Category, [DefinedType.Name], Value