Try {
write-host "starting build statistics!"
write-host ""

write-host "getting variables..."
$startTime = $env:SYSTEM_PIPELINESTARTTIME
$endTime = Get-Date
$buildNumber = $env:BUILD_BUILDNUMBER
$status = $env:AGENT_JOBSTATUS
$dbConn = $env:DATACONNECTIONSTRING

write-host "startTime: $startTime"
write-host "endTime: $endTime"
write-host "buildNumber: $buildNumber"
write-host "status: $status"
write-host "dbConn: $dbConn"
    
write-host ""
write-host "setting insert statement..."
$insert = "INSERT INTO [Bucket].[BuildStatistics] ([Start], [End], [BuildNumber], [Status], [Type]) VALUES (convert(DATETIME, convert(DATETIME2, '$startTime')), convert(DATETIME, '$endTime'), '$buildNumber', '$status', 'CICD Pipeline-Website')";
write-host "insert statement: $insert"

$conn = New-Object System.Data.SqlClient.SqlConnection($dbConn)
write-host "opening connection..."
$conn.Open()
write-host "creating command..."
$cmd = $conn.CreateCommand()

$cmd.CommandText = $insert
write-host "running insert..."
$cmd.ExecuteNonQuery()

write-host "closing connection..."
$conn.Close()

write-host "Done!"
}
Catch {
write-host "Error: $_"
}