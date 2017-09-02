# HonestMiddleware

Functional Owin Middleware with an honest function signiture.  this extension library lets you inject dependancies directly at the USE call and will colse over the dependancies before the deligate is passed to the Owin framework.
so you can define your middleware like this:
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
