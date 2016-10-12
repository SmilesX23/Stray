using UnityEngine;
using System.Collections;

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

using YamlDotNet.RepresentationModel;

public class PersistentData : MonoBehaviour {

    #region member variables

    public string m_file = "Settings.yaml";

    //fountains
    public bool m_wellsDeplete = false;
    public float m_wellLightAmount = 100F;
    public float m_wellLightRecharge = 100F;

    //player
    public float m_playerLightPool = 100F;
    public float m_playerLightCOnsumption = 0.5F;

    public bool m_playerCanGhost = false;

    #endregion

    void Awake ()
    {
        //load all the various settings from the YAML file
        StringReader input = new StringReader(System.IO.File.ReadAllText(m_file));

        YamlStream yaml = new YamlStream();
        yaml.Load(input);

        YamlMappingNode mapping = (YamlMappingNode)yaml.Documents[0].RootNode;
        
        foreach (var setting in mapping.Children)
        {
            if (((YamlScalarNode)setting.Key).Value == "WellDepletes")
            {
                print(((YamlScalarNode)setting.Key).Value);
            }
        }
    }

	void Update ()
    {
	    
	}
}
