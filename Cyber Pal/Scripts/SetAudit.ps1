param ($auditFailure, $auditSuccess, $category)

echo auditpol /set /subcategory:"$category" /failure:$auditFailure /success:$auditSuccess
auditpol /set /subcategory:"$category" /failure:$auditFailure /success:$auditSuccess