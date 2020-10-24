# ReferenceErrorBug
This is a bug min demo for vs prompting error.

###### DotNet Issue URL:
https://github.com/microsoft/dotnet/issues/1260

###### DotNet Issue #1260:
This is a bug min demo for vs prompting error. The code is right, you can new a project for testing. URL: https://github.com/kelicto/ReferenceErrorBug.git.

Now, I already know the reason, because the language version is 7.1 in project file. So, the prompting happened. Please fix it and tell me explicit reason. If the language version has some bugs, please check it and fix it, because it's very important and substantive. Thanks!

The language version 7.3 is ok, so, old versions have the some bugs and I think need to fix, otherwise, don't allow define non supported overload methods and should not say 'xxx' parameters problems, It's very terrible. It seem to be difficult, because it means that some versions should republish.

Of course, I have an easy solution for this that all referenced libraries should tell caller the language version and give them smart tips when the version of it is the later.
