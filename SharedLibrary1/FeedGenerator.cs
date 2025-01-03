using System.ServiceModel.Syndication;

namespace SharedLibrary1;

public class FeedGenerator
{
    public SyndicationFeed GenerateFeed()
    {

        // Set basic feed information
        var feed = new SyndicationFeed("Feed Title", "Feed Description", new Uri("http://example.com"));

        // Create feed items
        var items = new SyndicationItem[]
        {
            new (
                "Item 1 Title",
                "Item 1 Content",
                new Uri("http://example.com/item1"),
                "Item 1 ID",
                DateTimeOffset.Now
            ),
            new (
                "Item 2 Title",
                "Item 2 Content",
                new Uri("http://example.com/item2"),
                "Item 2 ID",
                DateTimeOffset.Now
            )
        };

        // Add items to the feed
        feed.Items = items;

        return feed;
    }
}
