using Android.Widget;
using Xamarin.Forms;
using Com.Squareup.Picasso;
using System.Collections.Generic;

[assembly: Dependency(typeof(PicassoForm.Droid.Picasso_Android))]
namespace PicassoForm.Droid
{
    class Picasso_Android : IPicasso
    {
        public void Get(string contentDesc, string url)
        {
            List<Android.Views.View> outViews = new List<Android.Views.View>();
            Android.Views.View root = MainActivity.activity.Window.DecorView.FindViewById(Android.Resource.Id.Content);
            CustomFindView(root, contentDesc, ref outViews);
            if (outViews.Count > 0)
            {
                Picasso.With(Android.App.Application.Context).Load(url).Into((ImageView)outViews[0]);
            }
        }
        public void CustomFindView(Android.Views.View view, string contentDesc, ref List<Android.Views.View> outViews)
        {
            if (view is Android.Views.ViewGroup parent)
            {
                for (int i = 0; i < parent.ChildCount; i++)
                {
                    CustomFindView(parent.GetChildAt(i), contentDesc, ref outViews);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(view.ContentDescription) && view.ContentDescription.Equals(contentDesc))
                {
                    outViews.Add(view);
                }
            }
        }
    }
}