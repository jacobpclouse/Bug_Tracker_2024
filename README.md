# Graph_API_Parser
URL BUILDER: So the user can graphically build out the possible graph api uris based on the body, input, etc in powerautomate (get all the possible apps from the docs), and allow them to copy the build url string
    - Dropdown with program, what attributes

POWERAUTOMATE: Allow users to then take the built out uri and format it for the use in powerautomate, they would just need to specify if the input is body, output, etc.
    - Have them paste in the result into Expression view

?? GENERATE BEARER TOKEN: Potentially have this app generate a bearer token so they can use it with Postman. 
    - Have it GET and display results / save results to a json file

## Features:
- ms authentication (browser/graph/azure auth)
- show potential uri paths (options for overarching uri)

## How To Run:
1) Clone app and cd into the folder
2) For Live Reload, use ```dotnet watch run``` 