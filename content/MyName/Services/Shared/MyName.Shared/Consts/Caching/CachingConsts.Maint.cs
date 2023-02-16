namespace MyName.Shared.Consts.Caching.Maint;

public class CachingConsts : Common.CachingConsts
{
    public const string DictPreheatedKey = "MyName:maint:dicts:preheated";
    public const string CfgPreheatedKey = "MyName:maint:cfgs:preheated";

    public const string DictSingleKeyPrefix = "MyName:maint:dicts:single";
    public const string CfgSingleKeyPrefix = "MyName:maint:cfgs:single";

    public const string BloomfilterOfCacheKey = "MyName:maint:bloomfilter:cachekeys";
}