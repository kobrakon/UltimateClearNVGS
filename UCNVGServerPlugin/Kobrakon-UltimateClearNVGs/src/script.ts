/* eslint-disable @typescript-eslint/no-var-requires */
/* eslint-disable no-constant-condition */
/* eslint-disable prefer-const */

// i know theres a much better way to do this I tried doing shit with switch statements to make it more efficient but it was being a bitch
// asshole
import { DependencyContainer } from "tsyringe";
import { IPostDBLoadMod } from "@spt-aki/models/external/IPostDBLoadMod";
import { DatabaseServer } from "@spt-aki/servers/DatabaseServer";
import { ILogger } from "@spt-aki/models/spt/utils/ILogger";
import config from "../config.json";

class UCNVG implements IPostDBLoadMod
{
    public postDBLoad(container: DependencyContainer): void
    {
        const Logger = container.resolve<ILogger>("WinstonLogger");
        const database = container.resolve<DatabaseServer>("DatabaseServer").getTables();
        const items = database.templates.items;
        let value = 0;
        
        Logger.info("doing spooky server shit with you NVGs")
        
        const GPNVG = items["5c0558060db834001b735271"]
        const PNV10T = items["5c0696830db834001d23f5da"]
        const N15 = items["5c066e3a0db834001b7353f0"]
        const PVS14 = items["57235b6f24597759bf5a30f1"]
        const T7 = items["57235b6f24597759bf5a30f1"]

        if (config.MasterFunction.Enabled == true)
        {
            if (config.GPNVG.ApplyChanges)
            {
                GPNVG._props.Color =
                {
                    "r": config.GPNVG.R,
                    "g": config.GPNVG.G,
                    "b": config.GPNVG.B,
                    "a": config.GPNVG.A
                }
            }
            if (config.PNV10T.ApplyChanges)
            {
                PNV10T._props.Color =
                {
                    "r": config.PNV10T.R,
                    "g": config.PNV10T.G,
                    "b": config.PNV10T.B,
                    "a": config.PNV10T.A
                }
            }
            if (config.N15.ApplyChanges)
            {
                N15._props.Color =
                {
                    "r": config.N15.R,
                    "g": config.N15.G,
                    "b": config.N15.B,
                    "a": config.N15.A
                }
            }
            if (config.PVS14.ApplyChanges)
            {
                PVS14._props.Color =
                {
                    "r": config.PVS14.R,
                    "g": config.PVS14.G,
                    "b": config.PVS14.B,
                    "a": config.PVS14.A
                }
            }
        }
    }
}

module.exports = { mod: new UCNVG() }
