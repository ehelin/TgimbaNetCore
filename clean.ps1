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
    $uri =  "$server$directory" 
    write-host "url: " + $uri

	# TODO - refactor to another method
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

    Foreach ($fileDirectory in $files) 
    {
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
            write-host deleteing $fileDirectory

            # start delete file =========================================================================
			# TODO - refactor
            $deleteFile = "$uri/$fileDirectory"
            $ftprequest = [System.Net.FtpWebRequest]::create($deleteFile)
            $ftprequest.Credentials =  New-Object System.Net.NetworkCredential($username, $password)

            try
            {
               $ftprequest.Method = [System.Net.WebRequestMethods+Ftp]::DeleteFile
               $ftprequest.GetResponse() | Out-Null
            }
            catch
            {
				Write-Host $_.Exception.Message
            }
            # end delete file =========================================================================
        }
    }

    if ($isFile -eq "true")
    {
        #start delete directory containing files just deleted ==============================
		# TODO - refactor
        $ftprequest = [System.Net.FtpWebRequest]::create($uri)
        $ftprequest.Credentials =  New-Object System.Net.NetworkCredential($username, $password)

        try
        {
            $ftprequest.Method = [System.Net.WebRequestMethods+Ftp]::RemoveDirectory
            $ftprequest.GetResponse() | Out-Null
        }
        catch
        {
			Write-Host $_.Exception.Message
        }
    }
    #end delete directory containing files just deleted ================================

}
catch {
    write-host -message $_.Exception.InnerException.Message
}

    $StreamReader.close()
    $ResponseStream.close()
    $FTPResponse.Close()

    Return $files


}

$server = ''
$username = ''
$password = ''
$directory =''

CleanFtpSite -server $server -username $username -password $password -directory $directory

Write-Output $filelist