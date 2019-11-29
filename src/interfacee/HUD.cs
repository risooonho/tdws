using Godot;
using tdws.actors.player;
using tdws.utils;

namespace tdws.interfacee
{
  /// <summary>
  ///   The heads up display. Displays health and amount of coins.
  /// </summary>
  public class HUD : Control, IHealthChangeListener, IChatListener
  {
    private RichTextLabel _chat;
    private RichTextLabel _coins;
    private RichTextLabel _health;

    public void AddChat(string message)
    {
      ClearChat();
      AddChat(message, Colors.White);
    }

    public void AddChat(string message, Color color)
    {
      if (message == null) return;

      _chat.AddText(message);
    }

    public void HealthChanged(int amount)
    {
      SetHealth(amount);
    }

    public override void _Ready()
    {
      _coins = GetNode("Coins") as RichTextLabel;
      _health = GetNode("Health") as RichTextLabel;
      _chat = GetNode("Chat") as RichTextLabel;

      var signalManager = SignalManager.GetInstance();
      signalManager.AddHealthChangeListener(this);
      signalManager.AddChatListener(this);

      SetHealth(666);
      SetCoins(123);
    }

    /// <summary>
    ///   Updates the amount of health displayed.
    /// </summary>
    /// <param name="amount">
    ///   The amount of health to display.
    /// </param>
    private void SetHealth(int amount)
    {
      _health.SetText(amount.ToString());
    }

    /// <summary>
    ///   Updates the amount of coins displayed.
    /// </summary>
    /// <param name="amount">
    ///   The amount of coins to display.
    /// </param>
    private void SetCoins(int amount)
    {
      _coins.SetText(amount.ToString());
    }

    /// <summary>
    ///   Clears the chat.
    /// </summary>
    private void ClearChat()
    {
      _chat.Clear();
    }
  }
}