using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Records;
using OrchardCore.Lists.Helpers;
using YesSql;

public static class ListOrchardHelperExtensions
{
    /// <summary>
    /// Returns list count.
    /// </summary>
    /// <param name="listContentItemId">The list content item id.</param>
    /// <param name="itemPredicate">The optional predicate applied to each item. By defult published items only.</param>
    /// <returns>A number of list items satisfying given predicate.</returns>
    public static async Task<int> QueryListItemsCountAsync(this IOrchardHelper orchardHelper, string listContentItemId, Expression<Func<ContentItemIndex, bool>> itemPredicate = null)
    {
        var session = orchardHelper.HttpContext.RequestServices.GetService<ISession>();

        return await ListQueryHelpers.QueryListItemsCountAsync(session, listContentItemId, itemPredicate);
    }

    /// <summary>
    /// Returns list items.
    /// </summary>
    /// <param name="listContentItemId">The list content item id.</param>
    /// <param name="itemPredicate">The optional predicate applied to each item. By defult published items only.</param>
    /// <returns>An enumerable of list items satisfying given predicate.</returns>
    public static async Task<IEnumerable<ContentItem>> QueryListItemsAsync(this IOrchardHelper orchardHelper, string listContentItemId, Expression<Func<ContentItemIndex, bool>> itemPredicate = null)
    {
        var session = orchardHelper.HttpContext.RequestServices.GetService<ISession>();

        return await ListQueryHelpers.QueryListItemsAsync(session, listContentItemId, itemPredicate);
    }
}
