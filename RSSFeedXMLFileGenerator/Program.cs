using System.ServiceModel.Syndication;
using System.Xml;
using CommandLineSwitchParser;

var option = CommandLineSwitch.Parse<CommandLineOptions>(ref args);

// Set basic feed information
var feed = new SharedLibrary1.FeedGenerator().GenerateFeed();

// Save the RSS feed to a XML file
var feedPath = Path.GetFullPath(option.OutputPath ?? "feed.xml");
Directory.CreateDirectory(Path.GetDirectoryName(feedPath)!);
using var writer = XmlWriter.Create(feedPath);
var rssFormatter = new Rss20FeedFormatter(feed);
rssFormatter.WriteTo(writer);
