## Thinktecture Identity Server 3 Dockerfile
This is a starting point for anyone interested in running Thinktecture's IDSv3 in a Docker container on Linux.

**DO NOT USE FOR PRODUCTION!**

### Starting a container
To run a quick temporary container: 
 
```{bash}
# docker pull ryan1234/thinktecture-idp
# docker run -it --rm --name idp -p 44319:44319 ryan1234/thinktecture-idp
# curl http://localhost:44320/core/.well-known/openid-configuration
```

### Work in Progress
There are a few issues with running the Identity Server on Mono. This is why there are three forked DLLs that are copied over existing NuGet packages. As the issues with each DLL get resolved, the forked DLLs will disappear.

1. System.IdentityModel.Tokens.JWT.dll has this open issue for Mono: https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet/issues/168
2. Thinktecture.IdentityServer3.dll has this open issue for Mono: https://github.com/IdentityServer/IdentityServer3/issues/1373
