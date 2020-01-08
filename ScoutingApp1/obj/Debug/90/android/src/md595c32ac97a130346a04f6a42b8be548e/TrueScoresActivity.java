package md595c32ac97a130346a04f6a42b8be548e;


public class TrueScoresActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("ScoutingApp1.TrueScoresActivity, ScoutingApp1", TrueScoresActivity.class, __md_methods);
	}


	public TrueScoresActivity ()
	{
		super ();
		if (getClass () == TrueScoresActivity.class)
			mono.android.TypeManager.Activate ("ScoutingApp1.TrueScoresActivity, ScoutingApp1", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
