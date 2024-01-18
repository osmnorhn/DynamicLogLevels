# DynamicLogLevels

This app demonstrates using dotnet core appsettings file with reloadOnChange option in combination with K8s. The K8s configmap is used to mount a volume with a file that overrides serilog logging settings. Editing the configmap causes the logging level to be updated dynamically without service restart. Note the DOTNET_USE_POLLING_FILE_WATCHER option in dockerfile. It is needed for reloadOnChange to work with symlinks; K8s mounts configmap as a symbolic link. Execute the DynamicLogsWebApp\run.ps1 to build and deploy the service, then edit the configmap.
