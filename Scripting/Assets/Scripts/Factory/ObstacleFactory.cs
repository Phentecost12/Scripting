using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFactory
{
    private readonly ObstacleFactoryConfig config;

    public ObstacleFactory(ObstacleFactoryConfig config) 
    {
        this.config = config;  
    }
}
