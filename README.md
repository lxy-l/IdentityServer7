# 基于IdentityServer4的认证授权框架
>IdentityServer4原项目已不再维护，只能自己维护升级了   
>原项目地址：(https://github.com/IdentityServer/IdentityServer4)  
>原项目文档：(https://identityserver4.readthedocs.io)

# 变更记录
1. 重新整理项目结构（移除单元测试，HOST，脚本，示例等文件）
2. 去除部分Nuget包例如MinVer，XUnit，Newtonsoft.Json等
3. 使用System.Text.Json包代替原来Newtonsoft.Json包
4. 更新项目基础版本为.NET7.0
5. 重新命名项目为IdentityServer7
6. 升级相关依赖包
7. 重写ClaimConverter类
8. 重写TokenExtensions中的CreateJwtPayload方法
9. 修复升级后的相关错误

## Acknowledgements
IdentityServer7 is built using the following great open source projects and free services:

* [ASP.NET Core](https://github.com/dotnet/aspnetcore)
* [Bullseye](https://github.com/adamralph/bullseye)
* [SimpleExec](https://github.com/adamralph/simple-exec)
* [MinVer](https://github.com/adamralph/minver)
* [Json.Net](http://www.newtonsoft.com/json)
* [XUnit](https://xunit.github.io/)
* [Fluent Assertions](http://www.fluentassertions.com/)
* [GitReleaseManager](https://github.com/GitTools/GitReleaseManager)
* [IdentityServer4](https://github.com/IdentityServer/IdentityServer4)

..and last but not least a big thanks to all our [contributors](https://github.com/IdentityServer/IdentityServer4/graphs/contributors)!
