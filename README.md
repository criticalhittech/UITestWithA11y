# Xamarin.UITest for Accessible Apps

This app demonstrates how to overcome challenges involved in using
Xamarin.UITest with apps that need to support accessibility on Android.

To understand the challenge, run the app as-is on Android with TalkBack enabled
to see how it behaves. Then modify UITestDemo\MarkupExtensions\UITestModeExtesnsion.cs
to set:

```
public static bool IsInUiTestMode { get; set; } = true;
```

And rerun the app with TalkBack. This second run has the information needed
for tests using Xamarin.UITest to succeed.

There is no platform or version-dependent code involved, just:
1. a Xamarin.Forms markup extension
2. a hidden button on the initial page
3. and making sure to use the markup extension whenenver setting AutomationId

See post at https://criticalhittech.com/2021/07/29/using-xamarin-uitest-with-accessible-xamarin-forms-apps/ for more details.
