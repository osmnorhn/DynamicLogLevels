docker build -f Dockerfile -t dynamic-logs:latest $PSScriptRoot/../

kubectl config use-context docker-desktop --namespace default
kubectl apply -f $PSScriptRoot/k8s/cm.yaml
kubectl apply -f $PSScriptRoot/k8s/deployment.yaml