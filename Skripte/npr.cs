using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;
using ArduinoBluetoothAPI;
using System;
using System.Text;


public class npr : MonoBehaviour
{

	string message;
	public BluetoothHelper BTHelper;


	public GameObject[] spheres;

	public Material[] materials;

	public GameObject naspoji;

	public string x;
	public string received_message;
	public string received_message2;
	public static string varijabla;



	void Start()
	{
		DontDestroyOnLoad(gameObject);
		try
		{
			x = "";
			BTHelper = BluetoothHelper.GetInstance("HC-05");
			BTHelper.OnConnected += OnBluetoothConnected; //OnBluetoothConnected is a function defined later on
			BTHelper.setTerminatorBasedStream("\n"); //delimits received messages based on \n char
			//Debug.Log("" + BTHelper.getPairedDevicesList().Count);

			BTHelper.OnConnectionFailed += (helper) =>{
				Debug.Log("Failed to connect");
            };

			/*foreach(BluetoothDevice d in BTHelper.getPairedDevicesList()){
				Debug.Log(d.DeviceName);
            }
			*/
			BTHelper.OnDataReceived += (helper) => {
				try
				{
					string xx = helper.Read();
					char[] data = xx.ToCharArray();
					received_message = xx;
					varijabla = xx;
					received_message2 = xx;
					Debug.Log(received_message2);

					//Debug.Log("scena  1" + xx);

					if (data.Length != 3)
					{
						return;
					}

					int i = 0;
					if (data[0] != 'S')
						return;
					if (data[1] == 'E')
						i = 1;
					if (data[2] > 7)
						return;

					spheres[data[2] - 2].GetComponent<Renderer>().material = materials[i];
				}
				catch (Exception ex)
				{
					x += ex.Message;
				}
			};

			BTHelper.Connect();

		}
		catch (Exception ex)
		{
			Debug.Log(ex);
			x = ex.ToString();
			throw ex;
		}
	}

    

	void OnBluetoothConnected(BluetoothHelper helper)
	{
		Debug.Log("Connected");
		try
		{
			helper.StartListening();
			Debug.Log(helper.getDeviceName());
			StartCoroutine(blinkLED());

		}
		catch (Exception ex)
		{
			x += ex.ToString();
			Debug.Log(ex.Message);
		}

	}

	IEnumerator blinkLED()
	{
		byte[] turn_on = new byte[] { (byte)'E' /*E stands for enable */, 2 };
		byte[] turn_off = new byte[] { (byte)'D' /*D stands for disable */, 2 };
		x += BTHelper.isConnected().ToString();

		while (BTHelper.isConnected())
		{
			//Debug.Log("ON" + BTHelper.getPairedDevicesList()+BTHelper.Read());
			for (byte i = 2; i < 8; i++)
			{
				turn_on[1] = i;
				try
				{
					BTHelper.SendData(turn_on);

				}
				catch (Exception) { }
				yield return new WaitForSeconds(0.3f);
			}
			//Debug.Log("OFF");
			for (byte i = 2; i < 8; i++)
			{
				turn_off[1] = i;
				try
				{
					BTHelper.SendData(turn_off);
				}
				catch (Exception) { }
				yield return new WaitForSeconds(0.3f);
			}
		}

	}



	/*
	void OnGUI()
	{

		if (BTHelper == null)
			return;


		BTHelper.DrawGUI();

		if (!BTHelper.isConnected())
			if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 10, Screen.height / 10, Screen.width / 5, Screen.height / 10), "Connect"))
			{
				if (BTHelper.isDevicePaired())
					BTHelper.Connect(); // tries to connect

                else
                {
					Debug.Log("wrong");
                }
			}

		if (BTHelper.isConnected())
			if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 10, Screen.height - 2 * Screen.height / 10, Screen.width / 5, Screen.height / 10), "Disconnect"))
			{
				BTHelper.Disconnect();
			}

		
	}
	*/
	/*
	public void naklikspojeno()
    {

		Debug.Log("pritisnuo si spoji");
		if (!BTHelper.isConnected())
		{
			if (BTHelper.isDevicePaired())
				BTHelper.Connect(); // tries to connect

			else
			{
				Debug.Log("wrong");
			}
		}

	}
	*/
	void OnDestroy()
	{
		if (BTHelper != null)
			BTHelper.Disconnect();
	}
	
}





