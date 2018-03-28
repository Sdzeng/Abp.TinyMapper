# Abp.TinyMapper
Abp.TinyMapper with Abp https://github.com/aspnetboilerplate/aspnetboilerplate. (Not support .net core.)    

[![Nuget downloads](https://img.shields.io/nuget/v/tinymapper.svg)](https://www.nuget.org/packages/Abp.TinyMapper/)
[![GitHub license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/Sdzeng/Abp.TinyMapper/blob/master/LICENSE)



## Installation

Available on [nuget](https://www.nuget.org/packages/TinyMapper/)

	PM> Install-Package Abp.TinyMapper

## Getting Started

### In module file
```csharp
public override void PreInitialize()
{
    Configuration.Modules.AbpTinyMapper().EnableAutoBinding = true;
    Configuration.Modules.AbpTinyMapper().EnablePolymorphicMapping = true;
    Configuration.Modules.AbpTinyMapper().Configurators.Add(() =>
    { 
    //custom your tiny bind
    });
}
```
### Attribute 
#### TinyMapAttribute 
#### TinyMapFromAttribute 
#### TinyMapToAttribute 

### Map 
```csharp
[TinyMap(typeof(Info))]
public class Dto{
  public int Id{get;set;}
  public string Name{get;set;}
}

public class Info{
  public int Id{get;set;}
  public string Name{get;set;}
}

var dto=new Dto{id=1,Name="Sdzeng"};
var info=dto.MapTo<Info>();
dto=info.MapTo<Dto>();
```
