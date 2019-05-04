
Function DeleteFile {
Param
(
 [string]$username,
 [string]$password,
 [string]$fileDirectory,
 [string]$uri,
 [string]$isFile
)
	write-host "DeleteFile(args)"

    $deletePath = "";
    
    if ($isFile -eq "true") 
    {
        $deletePath = "$uri/$fileDirectory"
    } 
    else 
    {
        $deletePath = "$uri"
    }
	write-host "delete path: $deletePath"
    
    $ftprequest = [System.Net.FtpWebRequest]::create($deletePath)
    $ftprequest.Credentials =  New-Object System.Net.NetworkCredential($username, $password)

    try
    {
        if ($isFile -eq "true") {
            $ftprequest.Method = [System.Net.WebRequestMethods+Ftp]::DeleteFile
        } else {
            $ftprequest.Method = [System.Net.WebRequestMethods+Ftp]::RemoveDirectory
        }
        $ftprequest.GetResponse() | Out-Null
    }
    catch
    {
		Write-Host "DeleteFile(args)-Error: "$_.Exception.Message
    }
}

Function CleanFtpSite { 
Param 
(
 [System.Uri]$server,
 [string]$username,
 [string]$password,
 [string]$directory
)
    try 
    { 
	    write-host "CleanFtpSite(args)"
        $uri =  "$server$directory" 

        write-host ""
        write-host "Getting files ======================================================"
        write-host "uri: uri"
  
        $FTPRequest = [System.Net.FtpWebRequest]::Create($uri)
        $FTPRequest.Credentials = New-Object System.Net.NetworkCredential($username, $password)
        $FTPRequest.Method = [System.Net.WebRequestMethods+Ftp]::ListDirectory
        $FTPResponse = $FTPRequest.GetResponse() 
        $ResponseStream = $FTPResponse.GetResponseStream()
        
        $StreamReader = New-Object System.IO.StreamReader $ResponseStream  
        $files = New-Object System.Collections.ArrayList
        While ($fileDirectory = $StreamReader.ReadLine())
        {
            write-host "FileDirectory: " + $fileDirectory
            $files.Add($fileDirectory);
        }
        
        $StreamReader.close()
        $ResponseStream.close()
        $FTPResponse.Close()
        
        write-host ""
        write-host "Processing files ======================================================"
        Foreach ($fileDirectory in $files) 
        {
            write-host $fileDirectory
      
            $pos = $fileDirectory.IndexOf(".")
            $isFile = "false"

            # its a directory
            if ($fileDirectory.IndexOf(".") -le 0) 
            {
                write-host "directory: " + $fileDirectory
                CleanFtpSite -server $server -username $username -password $password -directory "$directory/$fileDirectory"
            }      
            # its a file
            else 
            {        
                $isFile = "true"

                write-host "file: " + $fileDirectory
                DeleteFile -username $username -password $password -fileDirectory $fileDirectory -uri $uri -isFile $isFile
            }           
        }         

        write-host "clean directory: " + $uri
        DeleteFile -username $username -password $password -fileDirectory $fileDirectory -uri $uri -isFile "false"
    }
    catch 
    {
		Write-Host "CleanFtpSite(args)-Error: "$_.Exception.Message
    }
}

$server = ''
$username = ''
$password = ''
$directory =''

CleanFtpSite -server $server -username $username -password $password -directory $directory

write-host "Done!"