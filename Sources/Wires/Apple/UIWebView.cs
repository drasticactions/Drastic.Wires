#if !TVOS
namespace Wires
{
	using System;
	using System.Linq.Expressions;
	using Transmute;
	using UIKit;
	using WebKit;

	public static partial class UIExtensions
	{
		#region HtmlContent (WK) property

		public static Binder<TSource, WKWebView> HtmlContent<TSource, TPropertyType>(this Binder<TSource, WKWebView> binder, Expression<Func<TSource, TPropertyType>> property, IConverter<TPropertyType, string> converter = null)
			where TSource : class
		{
			Action<WKWebView, string> setter = (b, v) => b.LoadHtmlString(v, null);
			Func<WKWebView, string> getter = (b) => { throw new InvalidOperationException("No synchronous way to get HTML from WKWebView"); } ; // FIXME add two way async bindings
			return binder.Property(property, getter, setter, converter);
		}

		#endregion
	}
}
#endif