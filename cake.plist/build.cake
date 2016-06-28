#addin "Cake.Plist"

Task("defect").Does(() =>
{
    var plist = File("./Info.plist");

    // Executing task: defect
    // An error occured when executing task 'defect'.
    // Error: Data at the root level is invalid. Line 1, position 1.
    var data = DeserializePlist(plist);

    //data["CFBundleShortVersionString"] = "1.1.1";
    //data["CFBundleVersion"] = "1.1.1+3131";

    //SerializePlist(plist, data);
});

// EXECUTION
RunTarget("defect");
