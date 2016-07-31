using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO; // for TextAsset

public class Theater : MonoBehaviour 
{
	private static Theater instance ;

	public static Theater Instance
	{
		get
		{
			if(instance == null) instance = GameObject.Find("Theater").GetComponent<Theater>();
			return instance ;
		}
	}

	public Dictionary<int, TheaterScripts> all_theater = new Dictionary<int, TheaterScripts>();

	//public List<TheaterScripts> theater = new List<TheaterScripts>();

	public TheaterScripts getTheaterScript(int scriptIndex)
	{
		if(all_theater[scriptIndex] != null)
			return all_theater[scriptIndex];
		else 
			return new TheaterScripts();
	}

	public void Start()
	{
		LoadCSV("csv/all_message");
	}

	public void LoadCSV(string filename)
	{
		Debug.Log("Load CSV : " + filename);

		TextAsset ta =	Resources.Load(filename) as TextAsset;

		string [] line = ta.text.Split('\n');

		int last_theater_id = 0;

		for (int i = 1; i < line.Length; ++i) {
			
			string [] elem = line[i].Split(',');

			Debug.Log("elem count = " + elem.Length);

			// Column Header:
			// 0        ,1     ,2       ,3              ,4            ,5
			// TheaterID,ItemID,ItemName,scriptContentID,scriptContent,scriptItem

			int theater_id = int.Parse(elem[0]);
			if (last_theater_id == theater_id) {

				// add script content
				string script_text = elem[4];
				all_theater[theater_id].scriptContent.Add(script_text);

				continue;
			}

			// new theater id process ...

			if (elem.Length > 6) {
				Debug.LogError("Header Error!");
				return;
			}

			TheaterScripts tempdata = new TheaterScripts();

			int item_id = int.Parse(elem[1]);
			string item_name = elem[2];

			List<string> scritp_list = new List<string>();

			string script_first_text = elem[4];
			scritp_list.Add(script_first_text);

			tempdata.ItemID = item_id;
			tempdata.ItemName = item_name;
			tempdata.scriptContent = scritp_list;

			string image_name = elem[5];
			if (!string.IsNullOrEmpty(image_name)) {
				tempdata.scriptItem = Resources.Load<Sprite>(image_name.Replace("\r", ""));
			}

			all_theater.Add(theater_id, tempdata);

			last_theater_id = theater_id;

		}

	}

}

[System.Serializable]
public class TheaterScripts
{
	public int ItemID;
	public string   ItemName ;
	public List<string>scriptContent ;
	public Sprite scriptItem;
}