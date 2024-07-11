/*
 * New Frontiers - This file is licensed under AGPLv3
 * Copyright (c) 2024 New Frontiers Contributors
 * See AGPLv3.txt for details.
 */
using Content.Client.UserInterface.Controls;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;

namespace Content.Client.Bank.UI;

[GenerateTypedNameReferences]
public sealed partial class WithdrawBankATMMenu : FancyWindow
{
    public Action? WithdrawRequest;
    public Action? DepositRequest;
    public int Amount;
    public WithdrawBankATMMenu()
    {
        RobustXamlLoader.Load(this);
        WithdrawButton.OnPressed += OnWithdrawPressed;
        Title = Loc.GetString("bank-atm-menu-title");
        WithdrawEdit.OnTextChanged += OnAmountChanged;
    }

    public void SetBalance(int amount)
    {
        BalanceLabel.Text = Loc.GetString("bank-atm-menu-cash-amount", ("amount", amount.ToString()));
    }

    public void SetEnabled(bool enabled)
    {
        WithdrawButton.Disabled = !enabled;
    }

    private void OnWithdrawPressed(BaseButton.ButtonEventArgs obj)
    {
        WithdrawRequest?.Invoke();
    }

    private void OnAmountChanged(LineEdit.LineEditEventArgs args)
    {
        if (int.TryParse(args.Text, out var amount))
        {
            Amount = amount;
        }    
    }
}
