# WebApiExample

## Build docker image:

``docker build -f "Dockerfile" --force-rm -t webapi:dev --target base  "C:\Users\Alvinek\source\repos\WebApi"``

### Create resource group:
``az group create --name <your_resoruce_group> --location eastus``

### Create ACR:
``az acr create --name <your_acr_name> --resourcegroup <your_resoruce_group> --sku basic --admin-enabled``

### Tag docker image: 
``docker tag webapi:latest <your_acr_name>.azurecr.io/webapi:v1``

### Login to ACR group:
``az acr login --name <your_acr_name>``

### Push docker image:
``docker push <your_acr_name>.azurecr.io/webapi:v1``

### Create AKS:
``az aks create --resource-group <your_resource_group> --name <your_aks_cluster_name> --node-count 1 --generate-ssh-keys``

### Get credentials for kubectl:
``az aks get-credentials --resource-group <your_resource_group> --name <your_aks_cluster_name>

