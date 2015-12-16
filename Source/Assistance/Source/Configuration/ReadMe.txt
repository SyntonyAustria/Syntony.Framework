EnterpriseLibrary Configuration System: http://msdn.microsoft.com/en-us/library/ff664549(v=pandp.50).aspx !!!!

http://www.codeproject.com/Articles/25829/User-Settings-Applied

http://www.codeproject.com/Articles/20548/Creating-a-Custom-Configuration-Section-in-C

http://joelabrahamsson.com/entry/creating-a-custom-configuration-section-in-net

http://www.planetgeek.ch/2009/02/23/configuration-sections-the-easy-way/

http://www.west-wind.com/presentations/configurationclass/configurationclass.asp

http://www.codeproject.com/Articles/16466/Unraveling-the-Mysteries-of-NET-2-0-Configuration
http://www.codeproject.com/Articles/16724/Decoding-the-Mysteries-of-NET-2-0-Configuration
http://www.codeproject.com/Articles/19675/Cracking-the-Mysteries-of-NET-2-0-Configuration

http://www.eggheadcafe.com/articles/20060622.asp

http://www.codeproject.com/Tips/199441/DLL-with-configuration-file

http://social.msdn.microsoft.com/Forums/de/visualcsharpde/thread/2b9f5d34-4058-40e5-87c3-4c4844308c10

****************************************************************************************
RENAME app.config to Syntony.Framework.config
****************************************************************************************


// Open the configuration file using the dll location
Configuration myDllConfig = ConfigurationManager.OpenExeConfiguration(this.GetType().Assembly.Location);


internal sealed partial class Settings 
{ 
    private List<ConfigurationElement> list; 
 
    /// <summary> 
    /// Initializes a new instance of the <see cref="Settings"/> class. 
    /// </summary> 
    public Settings() 
    { 
        this.OpenAndStoreConfiguration(); 
    } 
 
    /// <summary> 
    /// Opens the dll.config file and reads its sections into a private List of ConfigurationElement. 
    /// </summary> 
    private void OpenAndStoreConfiguration() 
    { 
        string codebase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase; 
        Uri p = new Uri(codebase); 
        string localPath = p.LocalPath; 
        string executingFilename = System.IO.Path.GetFileNameWithoutExtension(localPath); 
        string sectionGroupName = "applicationSettings"; 
        string sectionName = executingFilename + ".Properties.Settings"; 
        string configName = localPath + ".config"; 
        ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap(); 
        fileMap.ExeConfigFilename = configName; 
        Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None); 
 
        // read section of properties 
        var sectionGroup = config.GetSectionGroup(sectionGroupName); 
        var settingsSection = (ClientSettingsSection)sectionGroup.Sections[sectionName]; 
        list = settingsSection.Settings.OfType<ConfigurationElement>().ToList(); 
 
        // read section of Connectionstrings 
        var sections = config.Sections.OfType<ConfigurationSection>(); 
        var connSection = (from section in sections 
                           where section.GetType() == typeof(ConnectionStringsSection) 
                           select section).FirstOrDefault() as ConnectionStringsSection; 
        if (connSection != null) 
        { 
            list.AddRange(connSection.ConnectionStrings.Cast<ConfigurationElement>()); 
        } 
    } 
 
    /// <summary> 
    /// Gets or sets the <see cref="System.Object"/> with the specified property name. 
    /// </summary> 
    /// <value></value> 
    public override object this[string propertyName] 
    { 
        get 
        { 
            var result = (from item in list 
                         where Convert.ToString(item.ElementInformation.Properties["name"].Value) == propertyName 
                         select item).FirstOrDefault(); 
            if (result != null) 
            { 
                if (result.ElementInformation.Type == typeof(ConnectionStringSettings)) 
                { 
                    return result.ElementInformation.Properties["connectionString"].Value; 
                } 
                else if (result.ElementInformation.Type == typeof(SettingElement)) 
                { 
                    return result.ElementInformation.Properties["value"].Value; 
                } 
            } 
            return null; 
        } 
        // ignore 
        set 
        { 
            base[propertyName] = value; 
        } 
    } 
}
