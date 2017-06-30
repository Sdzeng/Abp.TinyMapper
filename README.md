# Abp.TinyMapper
Abp.TinyMapper with Abp https://github.com/aspnetboilerplate/aspnetboilerplate. 

Not support .net core.

# Usage
# 1.In module file

public override void PreInitialize()
{
    Configuration.Modules.AbpTinyMapper().EnableAutoBinding = true;
    Configuration.Modules.AbpTinyMapper().EnablePolymorphicMapping = true;
    Configuration.Modules.AbpTinyMapper().Configurators.Add(() =>
    { 
    //custom your tiny bind
    });
}

# 2.Attribute

TinyMapAttribute

TinyMapFromAttribute

TinyMapToAttribute

Demo
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
