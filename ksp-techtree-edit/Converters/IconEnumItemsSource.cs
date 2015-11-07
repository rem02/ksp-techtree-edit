

using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace ksp_techtree_edit.Converters
{
    public class IconEnumItemsSource : IItemsSource
    {
        public ItemCollection GetValues()
        {
            ItemCollection icon = new ItemCollection();
            icon.Add(IconsEnum.RDicon_generic, "Generic");
            icon.Add(IconsEnum.RDicon_start, "Start");
            icon.Add(IconsEnum.RDicon_basicrocketry, "Basic rocketry");
            icon.Add(IconsEnum.RDicon_generalrocketry, "General rocketry");
            icon.Add(IconsEnum.RDicon_survivability, "Survivability");
            icon.Add(IconsEnum.RDicon_stability, "Stability");            
            icon.Add(IconsEnum.RDicon_sciencetech, "Science tech");
            icon.Add(IconsEnum.RDicon_generalconstruction, "General construction");
            icon.Add(IconsEnum.RDicon_flightcontrol, "Flight control");
            icon.Add(IconsEnum.RDicon_advconstruction, "Adv construction");
            icon.Add(IconsEnum.RDicon_advflightcontrol, "Adv flight control");
            icon.Add(IconsEnum.RDicon_electrics, "Electrics");
            icon.Add(IconsEnum.RDicon_evatech, "Eva tech");
            icon.Add(IconsEnum.RDicon_advlanding, "Adv landing");
            icon.Add(IconsEnum.RDicon_heavyrocketry, "Heavy rocketry");
            icon.Add(IconsEnum.RDicon_fuelsystems, "Fuel systems");
            icon.Add(IconsEnum.RDicon_aerodynamicSystems, "Aerodynamic Systems");
            icon.Add(IconsEnum.RDicon_advexploration, "Adv exploration");
            icon.Add(IconsEnum.RDicon_emgineering101, "Emgineering101");
            icon.Add(IconsEnum.RDicon_precisionengineering, "Precision engineering");
            icon.Add(IconsEnum.RDicon_advelectrics, "Adv electrics");
            icon.Add(IconsEnum.RDicon_specializedcontrol, "Apecialized control");
            icon.Add(IconsEnum.RDicon_heavierrocketry, "Heavier rocketry");
            icon.Add(IconsEnum.RDicon_specializedconstruction, "Specialized construction");
            icon.Add(IconsEnum.RDicon_landing, "Landing");
            icon.Add(IconsEnum.RDicon_supersonicflight, "Super sonicflight");
            icon.Add(IconsEnum.RDicon_composites, "Composites");
            icon.Add(IconsEnum.RDicon_fieldscience, "Field science");
            icon.Add(IconsEnum.RDicon_nuclearpropulsion, "Nuclear propulsion");
            icon.Add(IconsEnum.RDicon_ionpropulsion, "Ion propulsion");
            icon.Add(IconsEnum.RDicon_largeelectrics, "Large electrics");
            icon.Add(IconsEnum.RDicon_electronics, "Electronics");
            icon.Add(IconsEnum.RDicon_highaltitudeflight, "High altitude flight");
            icon.Add(IconsEnum.RDicon_unmannedtech, "Unmanned tech");
            icon.Add(IconsEnum.RDicon_largecontrol, "Large control");
            icon.Add(IconsEnum.RDicon_advmetalworks, "Adv metal works");
            icon.Add(IconsEnum.RDicon_advaerodynamics, "Adv aerodynamics");
            icon.Add(IconsEnum.RDicon_metamaterials, "Meta materials");
            icon.Add(IconsEnum.RDicon_heavyaerodynamics, "Heavy aerodynamics");
            icon.Add(IconsEnum.RDicon_veryheavyrocketry, "Very heavy rocketry");
            icon.Add(IconsEnum.RDicon_advancedmotors, "Adv ancedmotors");
            icon.Add(IconsEnum.RDicon_hypersonicflight, "Hyper sonic flight");
            icon.Add(IconsEnum.RDicon_specializedelectrics, "Specialized electrics");
            icon.Add(IconsEnum.RDicon_advunmanned, "Adv unmanned");
            icon.Add(IconsEnum.RDicon_advsciencetech, "Adv science tech");
            icon.Add(IconsEnum.RDicon_experimentalrocketry, "Experimental rocketry");
            icon.Add(IconsEnum.RDicon_aerospaceTech, "Aerospace tech");
            icon.Add(IconsEnum.RDicon_experimentalelectrics, "Experimental electrics");
            icon.Add(IconsEnum.RDicon_experimentalaerodynamics, "Experimental aerodynamics");
            icon.Add(IconsEnum.RDicon_experimentalscience, "Experimental science");
            icon.Add(IconsEnum.RDicon_experimentalmotors, "Experimental motors");
            icon.Add(IconsEnum.RDicon_robotics, "Robotics");
            icon.Add(IconsEnum.RDicon_automation, "Automation");
            icon.Add(IconsEnum.RDicon_nanolathing, "Nanolathing");
            icon.Add(IconsEnum.RDicon_telescope, "Telescope");
            icon.Add(IconsEnum.RDicon_aerospaceTech2, "Aerospace tech 2");
            icon.Add(IconsEnum.RDicon_commandModules, "Command modules");
            icon.Add(IconsEnum.RDicon_advfuelSystems, "Adv fuel Systems");
            icon.Add(IconsEnum.RDicon_highPerformancefuelSystems, "High performance fuel systems");
            icon.Add(IconsEnum.RDicon_largeVolumeContainment, "Large volume containment");
            icon.Add(IconsEnum.RDicon_miniaturization, "Miniaturization");
            icon.Add(IconsEnum.RDicon_precisionpropulsion, "Precision propulsion");
            icon.Add(IconsEnum.RDicon_propulsionSystems, "Propulsion systems");
            icon.Add(IconsEnum.RDicon_basicprobes, "Basic probes");
            icon.Add(IconsEnum.RDicon_highaltitudepropulsion, "High altitude propulsion");
            icon.Add(IconsEnum.RDicon_largeprobes, "Large probes");

            return icon;
        }
    }
}
