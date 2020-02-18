//Всего в одну строчку вводится абстракция, 
//которая объединяет работу с управлением (IControls) 
//и позволяет  это управление отключать (IEnable)

public interface IEnableControls : IControls, IEnable { }
