# Recreation of EF SQL Provider not loading Navigation Properties bug?

When loading navigation properties with .Include() it does not load properties when a defaul property is set on the property trying to be included.

In this example, in PersonInstance.cs has a navigation property with a defaul value:
```
public Blob Blob { get; set; } = new Blob();
```

When calling EF in BlobController.cs:
```
var blobs = _context
                .Blobs
                .Include(b => b.PersonInstance)
                .FirstOrDefault(b => b.Id == idLong);
            
            var post = blobs.PersonInstance;
```
blob.PersonInstance is not set, and is null (even if blob has it's id set).

If I remove ` = new Blob();` everything works as expected.

Only recreated on SQL Provider nuget package `Microsoft.EntityFrameworkCore.SqlServer`, both on 5.0.11 and 3.1.14.
Not a problem in `Microsoft.EntityFrameworkCore.InMemory`

# How to start project?
In PlayingWithEF you find a project that will fail loading the navigation property in the BlobController.cs if you access the url: /Blob/1
You can create tables and data by running `CreateDb.sql` on an empty Db.
Remember to change the db name in appsettings.json to match
