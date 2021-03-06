/* Help Code Gen an AddPage for a migration.  Recently added pages will be listed last */
SELECT 
  CONCAT('AddPage("',parentPage.Guid, '","', p.Name,  '","',  p.Description,  '","',  p.Guid, '");')
FROM 
  cmsPage p
join cmsPage parentPage on p.ParentPageId = parentPage.Id
order by p.Id desc
