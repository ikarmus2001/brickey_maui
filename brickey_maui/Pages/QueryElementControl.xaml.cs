//namespace brickey_maui.Pages;

//public partial class QueryElementControl : ContentView
//{
//	public readonly BindableProperty TitleProperty
//		= BindableProperty.Create(nameof(Title), typeof(string), typeof(QueryElementControl),
//			propertyChanged: (bindable, oldValue, newValue) =>
//			{
//				var control = (QueryElementControl)bindable;
//				control.TitleLbl.Text = (string)newValue;

//            }
//	);

//	public readonly BindableProperty ThumbnailProperty
//		= BindableProperty.Create(nameof(Title), typeof(string), typeof(QueryElementControl),
//			propertyChanged: (bindable, oldValue, newValue) =>
//			{
//				var control = (QueryElementControl)bindable;
//                control.ThumbnailImg.Source = ImageSource.FromUri(new Uri((string)newValue));
//            }
//    );

//    public QueryElementControl()
//	{
//		InitializeComponent();
//	}

//	public string Title
//	{
//		get => GetValue(TitleProperty) as string;
//		set => SetValue(TitleProperty, value);
//	}

//	public string Thumbnail
//	{
//        get => GetValue(ThumbnailProperty) as string;
//        set => SetValue(ThumbnailProperty, value);
//    }
//}