using System.ServiceModel.Syndication;
using System.Xml;
using CommandLineSwitchParser;

var option = CommandLineSwitch.Parse<CommandLineOptions>(ref args);

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

// Save the RSS feed to a XML file
var feedPath = Path.GetFullPath(option.OutputPath ?? "feed.xml");
Directory.CreateDirectory(Path.GetDirectoryName(feedPath)!);
using var writer = XmlWriter.Create(feedPath);
var rssFormatter = new Rss20FeedFormatter(feed);
rssFormatter.WriteTo(writer);
