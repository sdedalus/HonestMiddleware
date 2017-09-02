# HonestMiddleware

Functional Owin Middleware with an honest function signature.  This extension library lets you inject 
dependencies directly at the USE call and will close over the dependencies before the delegate is passed 
to the Owin framework.
you can define your middleware like this:
```csharp
public Task WriteAsync(string what, PathString path, IOwinContext context, Func<Task> next)
{
	if (context.Request.Path == path)
		using (var writer = new StreamWriter(context.Response.Body))
		{
			return writer.WriteAsync(what);
		}
	else
	{
		return next();
	}
}
```
and register it like this:
```csharp
app.Use<string, PathString>("{'greeting':'Hello!'}", new PathString("/hello"), WriteAsync);
```
