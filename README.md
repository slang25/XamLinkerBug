# Xamarin Linker Bug

When using `System.Linq.Queryable` with an expression, like this:

```csharp
var list = new List<string> {"hello hello" };
output.Text = list.AsQueryable().GroupBy(x => x).FirstOrDefault()?.FirstOrDefault();
```

with "Link Framework SDKs Only" enabled and running on a physical iPhone there is an exception:

```
System.NullReferenceException: Object reference not set to an instance of an object
  at System.Linq.EnumerableRewriter.FindEnumerableMethod (System.String name, System.Collections.ObjectModel.ReadOnlyCollection`1[T] args, System.Type[] typeArgs) [0x00078] in /Library/Frameworks/Xamarin.iOS.framework/Versions/12.10.0.153/src/Xamarin.iOS/external/corefx/src/System.Linq.Queryable/src/System/Linq/EnumerableRewriter.cs:224
  at System.Linq.EnumerableRewriter.VisitMethodCall (System.Linq.Expressions.MethodCallExpression m) [0x0008d] in /Library/Frameworks/Xamarin.iOS.framework/Versions/12.10.0.153/src/Xamarin.iOS/external/corefx/src/System.Linq.Queryable/src/System/Linq/EnumerableRewriter.cs:42
  at System.Linq.Expressions.MethodCallExpression.Accept (System.Linq.Expressions.ExpressionVisitor visitor) [0x00000] in /Library/Frameworks/Xamarin.iOS.framework/Versions/12.10.0.153/src/Xamarin.iOS/external/corefx/src/System.Linq.Expressions/src/System/Linq/Expressions/MethodCallExpression.cs:109
  at System.Linq.Expressions.ExpressionVisitor.Visit (System.Linq.Expressions.Expression node) [0x00000] in /Library/Frameworks/Xamarin.iOS.framework/Versions/12.10.0.153/src/Xamarin.iOS/external/corefx/src/System.Linq.Expressions/src/System/Linq/Expressions/ExpressionVisitor.cs:34
  at System.Linq.Expressions.ExpressionVisitor.Visit (System.Collections.ObjectModel.ReadOnlyCollection`1[T] nodes) [0x00018] in /Library/Frameworks/Xamarin.iOS.framework/Versions/12.10.0.153/src/Xamarin.iOS/external/corefx/src/System.Linq.Expressions/src/System/Linq/Expressions/ExpressionVisitor.cs:48
  at System.Linq.EnumerableRewriter.VisitMethodCall (System.Linq.Expressions.MethodCallExpression m) [0x0000d] in /Library/Frameworks/Xamarin.iOS.framework/Versions/12.10.0.153/src/Xamarin.iOS/external/corefx/src/System.Linq.Queryable/src/System/Linq/EnumerableRewriter.cs:25
  at System.Linq.Expressions.MethodCallExpression.Accept (System.Linq.Expressions.ExpressionVisitor visitor) [0x00000] in /Library/Frameworks/Xamarin.iOS.framework/Versions/12.10.0.153/src/Xamarin.iOS/external/corefx/src/System.Linq.Expressions/src/System/Linq/Expressions/MethodCallExpression.cs:109
  at System.Linq.Expressions.ExpressionVisitor.Visit (System.Linq.Expressions.Expression node) [0x00000] in /Library/Frameworks/Xamarin.iOS.framework/Versions/12.10.0.153/src/Xamarin.iOS/external/corefx/src/System.Linq.Expressions/src/System/Linq/Expressions/ExpressionVisitor.cs:34
  at System.Linq.EnumerableExecutor`1[T].Execute () [0x00005] in <e6d849d701f746279057f9767763b0a2>:0
  at System.Linq.EnumerableQuery`1[T].System.Linq.IQueryProvider.Execute[TElement] (System.Linq.Expressions.Expression expression) [0x00036] in <e6d849d701f746279057f9767763b0a2>:0
  at System.Linq.Queryable.FirstOrDefault[TSource] (System.Linq.IQueryable`1[T] source) [0x0002f] in <e6d849d701f746279057f9767763b0a2>:0
  at XamLinkerBug.MainPage..ctor () [0x00021] in /Users/stuart/Projects/XamLinkerBug/XamLinkerBug/MainPage.xaml.cs:22
  at XamLinkerBug.App..ctor () [0x0000f] in /Users/stuart/Projects/XamLinkerBug/XamLinkerBug/App.xaml.cs:13
  at XamLinkerBug.iOS.AppDelegate.FinishedLaunching (UIKit.UIApplication app, Foundation.NSDictionary options) [0x00007] in /Users/stuart/Projects/XamLinkerBug/XamLinkerBug.iOS/AppDelegate.cs:26
  at at (wrapper managed-to-native) UIKit.UIApplication.UIApplicationMain(int,string[],intptr,intptr)
  at UIKit.UIApplication.Main (System.String[] args, System.IntPtr principal, System.IntPtr delegate) [0x00005] in /Library/Frameworks/Xamarin.iOS.framework/Versions/12.10.0.153/src/Xamarin.iOS/UIKit/UIApplication.cs:86
  at UIKit.UIApplication.Main (System.String[] args, System.String principalClassName, System.String delegateClassName) [0x0000e] in /Library/Frameworks/Xamarin.iOS.framework/Versions/12.10.0.153/src/Xamarin.iOS/UIKit/UIApplication.cs:65
  at XamLinkerBug.iOS.Application.Main (System.String[] args) [0x00001] in /Users/stuart/Projects/XamLinkerBug/XamLinkerBug.iOS/Main.cs:17

```

However when runnin on the simulator I do not see this issue.

Environment details:
```
=== Visual Studio Community 2019 (Preview) for Mac ===

Version 8.1 Preview (8.1 build 2734)
Installation UUID: d0f72ff2-1b2f-4611-a068-e1411a4b68e5
	GTK+ 2.24.23 (Raleigh theme)
	Xamarin.Mac 5.6.0.25 (d16-0 / 50f75273)

	Package version: 518010028

=== Mono Framework MDK ===

Runtime:
	Mono 5.18.1.28 (2018-08/223ea7ef92e) (64-bit)
	Package version: 518010028

=== NuGet ===

Version: 5.0.2.5988

=== .NET Core ===

Runtime: /usr/local/share/dotnet/dotnet
Runtime Versions:
	3.0.0-preview3-27503-5
	3.0.0-preview-27122-01
	2.2.5
	2.2.4
	2.2.3
	2.2.1
	2.2.0
	2.1.9
	2.1.6
	2.1.4
	2.1.2
	2.1.1
SDK: /usr/local/share/dotnet/sdk/3.0.100-preview3-010431/Sdks
SDK Versions:
	3.0.100-preview3-010431
	3.0.100-preview-009812
	2.2.300
	2.2.203
	2.2.105
	2.2.102
	2.2.101
	2.2.100
	2.1.505
	2.1.500
	2.1.402
	2.1.400
	2.1.302
	2.1.301
MSBuild SDKs: /Library/Frameworks/Mono.framework/Versions/5.18.1/lib/mono/msbuild/Current/bin/Sdks

=== Xamarin.Profiler ===

Version: 1.6.10
Location: /Applications/Xamarin Profiler.app/Contents/MacOS/Xamarin Profiler

=== Updater ===

Version: 11

=== Apple Developer Tools ===

Xcode 10.2.1 (14490.122)
Build 10E1001

=== Xamarin.Android ===

Version: 9.3.0.22 (Visual Studio Community)
Commit: HEAD/8e7764fdf
Android SDK: /Users/stuart/Library/Developer/Xamarin/android-sdk-macosx
	Supported Android versions:
		7.0 (API level 24)
		7.1 (API level 25)
		8.0 (API level 26)
		8.1 (API level 27)

SDK Tools Version: 26.1.1
SDK Platform Tools Version: 28.0.1
SDK Build Tools Version: 27.0.3

Build Information: 
Mono: mono/mono/2018-08@3cb36842fc4
Java.Interop: xamarin/java.interop/d16-1@5ddc3e3
LibZipSharp: grendello/LibZipSharp/d16-1@44de300
LibZip: nih-at/libzip/rel-1-5-1@b95cf3f
ProGuard: xamarin/proguard/master@905836d
SQLite: xamarin/sqlite/3.27.1@8212a2d
Xamarin.Android Tools: xamarin/xamarin-android-tools/d16-1@acabd26

=== Microsoft Mobile OpenJDK ===

Java SDK: /Users/stuart/Library/Developer/Xamarin/jdk/microsoft_dist_openjdk_8.0.25
1.8.0-25
Android Designer EPL code available here:
https://github.com/xamarin/AndroidDesigner.EPL

=== Android Device Manager ===

Version: 1.2.0.44
Hash: aac645b
Branch: remotes/origin/d16-1
Build date: 2019-05-29 19:55:24 UTC

=== Xamarin.Mac ===

Version: 5.10.0.153 (Visual Studio Community)
Hash: 750a8798
Branch: d16-1-artifacts
Build date: 2019-04-30 15:17:54-0400

=== Xamarin.iOS ===

Version: 12.10.0.153 (Visual Studio Community)
Hash: 750a8798
Branch: d16-1-artifacts
Build date: 2019-04-30 15:17:54-0400

=== Xamarin Designer ===

Version: 16.1.0.464
Hash: 66bb7b43f
Branch: remotes/origin/d16-1-new-document-model
Build date: 2019-06-07 07:10:32 UTC

=== Xamarin Inspector ===

Version: 1.4.3
Hash: db27525
Branch: 1.4-release
Build date: Mon, 09 Jul 2018 21:20:18 GMT
Client compatibility: 1

=== Build Information ===

Release ID: 801002734
Git revision: 6c95d6d393b9950dc48ddb7e845a6570071ae133
Build date: 2019-06-07 20:04:04+00
Build branch: release-8.1
Xamarin extensions: 0ac46762465f7fde32f6e8d8710f68c77e819e9f

=== Operating System ===

Mac OS X 10.14.4
Darwin 18.5.0 Darwin Kernel Version 18.5.0
    Mon Mar 11 20:40:32 PDT 2019
    root:xnu-4903.251.3~3/RELEASE_X86_64 x86_64

=== Enabled user installed extensions ===

Xamarin.Forms HotReload extension 1.3.2
HotReloading 0.3.1

```