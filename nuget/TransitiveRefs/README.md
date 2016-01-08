# How to create MyCoolApp

* Projects created and added MSFT Visual C++ 2013 Runtime for UWP
* On each project
```
PM> install-package splat
PM> install-package akavache
```
* Update all packages to obtain $lib that is compatible with UWP (see https://github.com/ericsink/SQLitePCL.raw/issues/44)
```
PM> update-package
```
# MyFailingApplication
* Virigin project.json as result from installing packages, no user modifications.

# MyWorkingApplication
* Modified project.json

```
{
  "dependencies": {
    "akavache": {
        "version": "4.1.2",
        "suppressParent": "none"
    },
    "microsoft.bcl.build": "1.0.21",
    "Microsoft.NETCore.UniversalWindowsPlatform": "5.0.0",
    "Newtonsoft.Json": "8.0.1",
    "reactiveui": "6.5.0",
    "reactiveui-blend": "6.5.0",
    "refit": "2.4.1",
    "splat": "1.6.2",
    "SQLitePCL.raw_basic": {
      "version": "0.8.5"
    }
  },
  "frameworks": {
    "uap10.0": {}
  },
  "runtimes": {
    "win10-arm": {},
    "win10-arm-aot": {},
    "win10-x86": {},
    "win10-x86-aot": {},
    "win10-x64": {},
    "win10-x64-aot": {}
  }
}       
```

# MyOtherWorkingApplication
* Modified project.json

```
{
  "dependencies": {
    "akavache": "4.1.2",
    "microsoft.bcl.build": "1.0.21",
    "Microsoft.NETCore.UniversalWindowsPlatform": "5.0.0",
    "Newtonsoft.Json": "8.0.1",
    "reactiveui": "6.5.0",
    "reactiveui-blend": "6.5.0",
    "refit": "2.4.1",
    "splat": "1.6.2",
    "SQLitePCL.raw_basic": {
      "version": "0.8.5",
      "suppressParent": "none"
    }
  },
  "frameworks": {
    "uap10.0": {}
  },
  "runtimes": {
    "win10-arm": {},
    "win10-arm-aot": {},
    "win10-x86": {},
    "win10-x86-aot": {},
    "win10-x64": {},
    "win10-x64-aot": {}
  }
}
```

# MyOtherFailingApplication
* Modified project.json

```
{
 "dependencies": {
   "akavache": {
       "version": "4.1.2",
       "suppressParent": "none"
   },
   "microsoft.bcl.build": "1.0.21",
   "Microsoft.NETCore.UniversalWindowsPlatform": "5.0.0",
   "Newtonsoft.Json": "8.0.1",
   "reactiveui": "6.5.0",
   "reactiveui-blend": "6.5.0",
   "refit": "2.4.1",
   "splat": "1.6.2"
 },
 "frameworks": {
   "uap10.0": {}
 },
 "runtimes": {
   "win10-arm": {},
   "win10-arm-aot": {},
   "win10-x86": {},
   "win10-x86-aot": {},
   "win10-x64": {},
   "win10-x64-aot": {}
 }
}
```

# Definition of does not work
* Application crashes with the following when using x86 emulator target:

```
System.TypeInitializationException was unhandled by user code
 HResult=-2146233036
 Message=The type initializer for 'SQLitePCL.raw' threw an exception.
 Source=SQLitePCL.raw
 TypeName=SQLitePCL.raw
 StackTrace:
      at SQLitePCL.raw.sqlite3_open_v2(String filename, sqlite3& db, Int32 flags, String vfs)
      at Akavache.Sqlite3.Internal.SQLiteConnection..ctor(String databasePath, SQLiteOpenFlags openFlags, Boolean storeDateTimeAsTicks)
      at Akavache.Sqlite3.SQLitePersistentBlobCache..ctor(String databaseFile, IScheduler scheduler)
      at Akavache.Sqlite3.Registrations.<>c__DisplayClass6.<Register>b__2()
      at System.Lazy`1.CreateValue()
      at System.Lazy`1.LazyInitValue()
      at System.Lazy`1.get_Value()
      at Akavache.Sqlite3.Registrations.<>c__DisplayClass6.<Register>b__3()
      at Splat.ModernDependencyResolver.GetService(Type serviceType, String contract)
      at Splat.DependencyResolverMixins.GetService[T](IDependencyResolver This, String contract)
      at Akavache.BlobCache.get_UserAccount()
      <snip>

 InnerException: 
      HResult=-2146233052
      Message=Unable to load DLL 'sqlite3': The specified module could not be found. (Exception from HRESULT: 0x8007007E)
      Source=SQLitePCL.raw
      TypeName=""
      StackTrace:
           at SQLitePCL.SQLite3Provider.NativeMethods.sqlite3_win32_set_directory(UInt32 directoryType, String directoryPath)
           at SQLitePCL.SQLite3Provider..ctor()
           at SQLitePCL.raw..cctor()
      InnerException:
```      
