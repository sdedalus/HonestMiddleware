using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HonestMiddleware
{
	using AppFunc = Func<IDictionary<string, object>, Task>;
	using MiddleWare = Func<Func<IDictionary<string, object>, Task>, Func<IDictionary<string, object>, Task>>;

	public static class HonestMiddleware
	{
		public static IAppBuilder Use<T1>(this IAppBuilder app, T1 a, Func<T1, IOwinContext, Func<Task>, Task> handler)
		{

			return AppBuilderUseExtensions.Use(app, Adapt(handler)(a));
		}

		public static IAppBuilder Use<T1, T2>(this IAppBuilder app, T1 a, T2 b, Func<T1, T2, IOwinContext, Func<Task>, Task> handler)
		{
			return AppBuilderUseExtensions.Use(app, Adapt(handler)(a, b));
		}

		public static IAppBuilder Use<T1, T2, T3>(this IAppBuilder app, T1 a, T2 b, T3 c, Func<T1, T2, T3, IOwinContext, Func<Task>, Task> handler)
		{
			return AppBuilderUseExtensions.Use(app, Adapt(handler)(a, b, c));
		}

		public static IAppBuilder Use<T1, T2, T3, T4>(this IAppBuilder app, T1 a, T2 b, T3 c, T4 d, Func<T1, T2, T3, T4, IOwinContext, Func<Task>, Task> handler)
		{
			return AppBuilderUseExtensions.Use(app, Adapt(handler)(a, b, c, d));
		}

		public static IAppBuilder Use<T1, T2, T3, T4, T5>(this IAppBuilder app, T1 a, T2 b, T3 c, T4 d, T5 e, Func<T1, T2, T3, T4, T5, IOwinContext, Func<Task>, Task> handler)
		{
			return AppBuilderUseExtensions.Use(app, Adapt(handler)(a, b, c, d, e));
		}

		public static Func<T1, Func<IOwinContext, Func<Task>, Task>> Adapt<T1>(Func<T1, IOwinContext, Func<Task>, Task> implementation)
			=> a => (context, next) => implementation(a, context, next);

		public static Func<T1, T2, Func<IOwinContext, Func<Task>, Task>> Adapt<T1, T2>(Func<T1, T2, IOwinContext, Func<Task>, Task> implementation)
			=> (a, b) => (context, next) => implementation(a, b, context, next);

		public static Func<T1, T2, T3, Func<IOwinContext, Func<Task>, Task>> Adapt<T1, T2, T3>(Func<T1, T2, T3, IOwinContext, Func<Task>, Task> implementation)
			=> (a, b, c) => (context, next) => implementation(a, b, c, context, next);

		public static Func<T1, T2, T3, T4, Func<IOwinContext, Func<Task>, Task>> Adapt<T1, T2, T3, T4>(Func<T1, T2, T3, T4, IOwinContext, Func<Task>, Task> implementation)
			=> (a, b, c, d) => (context, next) => implementation(a, b, c, d, context, next);

		public static Func<T1, T2, T3, T4, T5, Func<IOwinContext, Func<Task>, Task>> Adapt<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5, IOwinContext, Func<Task>, Task> implementation)
			=> (a, b, c, d, e) => (context, next) => implementation(a, b, c, d, e, context, next);

		public static Func<T1, MiddleWare> Adapt<T1>(Func<T1, AppFunc, IDictionary<string, object>, Task> implementation)
					=> a => next => (IDictionary<string, object> context) => implementation(a, next, context);

		public static Func<T1, T2, MiddleWare> Adapt<T1, T2>(Func<T1, T2, AppFunc, IDictionary<string, object>, Task> implementation)
					=> (a, b) => next => (IDictionary<string, object> context) => implementation(a, b, next, context);

		public static Func<T1, T2, T3, MiddleWare> Adapt<T1, T2, T3>(Func<T1, T2, T3, AppFunc, IDictionary<string, object>, Task> implementation)
					=> (a, b, c) => next => (IDictionary<string, object> context) => implementation(a, b, c, next, context);

		public static Func<T1, T2, T3, T4, MiddleWare> Adapt<T1, T2, T3, T4>(Func<T1, T2, T3, T4, AppFunc, IDictionary<string, object>, Task> implementation)
					=> (a, b, c, d) => next => (IDictionary<string, object> context) => implementation(a, b, c, d, next, context);

		public static Func<T1, T2, T3, T4, T5, MiddleWare> Adapt<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5, AppFunc, IDictionary<string, object>, Task> implementation)
					=> (a, b, c, d, e) => next => (IDictionary<string, object> context) => implementation(a, b, c, d, e, next, context);
	}
}
