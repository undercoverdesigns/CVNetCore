# CVNetCore

CVNetCore is a .NET Core wrapper library for the ComicVine API.

## Installation

```
dotnet add PROJECT package CVNetCore
```

## Usage

```
ComicVine cvService = new ComicVine(YOUR_API_KEY);

List<Volume> results = cvService.GetVolumesByName("Star Wars");

foreach (Volume volume in results)
{
    Console.WriteLine($"{volume.Name}\t{volume.StartYear}\t{volume.Publisher?.Name}");
}

Volume volumeDetails = cvService.GetVolumeDetails(2914);

Console.WriteLine($"{volumeDetails.Name}\t{volumeDetails.StartYear}\t{volumeDetails.CountOfIssues}");

List<Issue> issues = cvService.GetIssuesByVolume(2914);

foreach (Issue issue in issues)
{
    Console.WriteLine($"{issue.Volume?.Name} ({issue.Volume?.StartYear}) #{issue.IssueNumber}");
}

Issue issueDetails = cvService.GetIssue(17616);

Console.WriteLine($"Issue #{issueDetails.IssueNumber}\t{issueDetails.IssueMonth}/{issueDetails.IssueYear}");
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## Thanks
Borrows quite a bit from https://github.com/mattwhetton/SharpComicVine

## License
[GNU GPLv3](https://choosealicense.com/licenses/gpl-3.0/)