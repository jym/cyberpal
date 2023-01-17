$Audits = auditpol /get /category:* /r | ConvertFrom-Csv 

foreach($Audit in $Audits) {
    $Audit."Exclusion Setting" = If ($Audit."Inclusion Setting" -eq "No Auditing") { "0" } else { "1" };
}

$Audits | ConvertTo-Csv -NoTypeInformation -UseQuotes AsNeeded