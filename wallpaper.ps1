#Retrieving image from APOD REST API https://api.nasa.gov/#apod
#TODO: pass date and API key in as user input parameters
$json = Invoke-WebRequest 'https://api.nasa.gov/planetary/apod?concept_tags=True&date=2024-06-05&api_key=Ec8ixequm0WkHlnG8R8ylMsaxW6tyRFip0Ws7Cir'
#Check to see if media-type = 'image' 
$url = ConvertFrom-Json $json | Select-Object -ExpandProperty 'hdurl'

# Write-Host $url

$path = 'C:\Users\Swathi Mukkamala\Desktop\APOD.jpg'

Invoke-WebRequest -Uri $url -OutFile $path

Write-Host 'Invoke-WebRequest done- downloaded'
Get-ItemProperty -Path 'HKCU:\Control Panel\Desktop\' -Name Wallpaper

# Setting path to empty string to reset overwritten APOD image path
# Set-ItemProperty -Path 'HKCU:\Control Panel\Desktop\' -Name Wallpaper -Value 'c:\Users\Swathi Mukkamala\Desktop\Mtns_desktop.jpg'
# # Set-ItemProperty -Path 'HKCU:\Control Panel\Desktop\' -Name Wallpaper -Value ''
# rundll32.exe user32.dll, UpdatePerUserSystemParameters 1,True

# Start-Sleep -Seconds 5

Set-ItemProperty -Path 'HKCU:\Control Panel\Desktop\' -Name Wallpaper -Value $path
rundll32.exe user32.dll, UpdatePerUserSystemParameters  1, True
# rundll32.exe user32.dll, UpdatePerUserSystemParameters

Get-ItemProperty -Path 'HKCU:\Control Panel\Desktop\' -Name Wallpaper