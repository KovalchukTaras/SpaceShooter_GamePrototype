using System;

public interface IMenuPanel
{
    public Action<int> OnSelected { get; set; }

    public void Select();
}
