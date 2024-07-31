param (
    [string]$BaseUrl,
    [string]$UserId,
    [string]$Token
)

$Headers = @{
    "Authorization" = "Bearer $Token"
    "Content-Type" = "application/json"
}

$deleteUserUrl = "$BaseUrl/Account/v1/User/$UserId"

try {
    $response = Invoke-WebRequest -Method 'DELETE' -Uri $deleteUserUrl -Headers $Headers
    
    if ($response.StatusCode -eq 204) {
        Write-Output "User deleted successfully"
    } else {
        Write-Output "Failed to delete user"
    }
} catch {
    Write-Output "An error occurred: $_"
}