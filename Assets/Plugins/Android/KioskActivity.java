package com.migifun.app.AndroidKiosk;

import com.unity3d.player.UnityPlayerActivity;
import android.content.DialogInterface;
import android.content.Context;
import android.content.Intent;
import android.content.ComponentName;
import android.os.Bundle;
import android.widget.Toast;
import android.app.admin.DevicePolicyManager;

public class KioskActivity extends UnityPlayerActivity 
{
  @Override
  protected void onCreate(Bundle savedInstanceState) 
  {
    super.onCreate(savedInstanceState);

    DevicePolicyManager myDevicePolicyManager = (DevicePolicyManager) getSystemService(Context.DEVICE_POLICY_SERVICE);
    ComponentName mDPM = new ComponentName(this, AdminReceiver.class);
    if (myDevicePolicyManager.isDeviceOwnerApp(getPackageName())) 
    {
      String[] packages = {getPackageName()};
      myDevicePolicyManager.setLockTaskPackages(mDPM, packages);
    } else {
      Toast.makeText(getApplicationContext(),"権限がない", Toast.LENGTH_LONG).show();
    }
  }
  
}