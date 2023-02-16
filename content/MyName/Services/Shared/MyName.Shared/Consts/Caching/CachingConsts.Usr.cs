namespace MyName.Shared.Consts.Caching.Usr;

public class CachingConsts : Common.CachingConsts
{
    //cache key
    public const string MenuListCacheKey = "MyName:usr:menus:list";

    public const string MenuTreeListCacheKey = "MyName:usr:menus:tree";
    public const string MenuRelationCacheKey = "MyName:usr:menus:relation";
    public const string MenuCodesCacheKey = "MyName:usr:menus:codes";

    public const string DetpListCacheKey = "MyName:usr:depts:list";
    public const string DetpTreeListCacheKey = "MyName:usr:depts:tree";
    public const string DetpSimpleTreeListCacheKey = "MyName:usr:depts:tree:simple";

    public const string RoleListCacheKey = "MyName:usr:roles:list";

    //cache prefix
    public const string UserValidatedInfoKeyPrefix = "MyName:usr:users:validatedinfo";

    //bloomfilter
    public const string BloomfilterOfAccountsKey = "MyName:usr:bloomfilter:accouts";
    public const string BloomfilterOfCacheKey = "MyName:usr:bloomfilter:cachekeys";
}