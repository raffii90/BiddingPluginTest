using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class BiddingController : MonoBehaviour {
    [SerializeField] private Button _bidButton;
    [SerializeField] private InputField _pbnGame;
    [SerializeField] private Dropdown _dealer;
    [SerializeField] private Dropdown _vulnerability;

    private List<Card> _northPlayerCards;
    private List<Card> _eastPlayerCards;
    private List<Card> _southPlayerCards;
    private List<Card> _westPlayerCards;

    private void Bid() {
        int vul = 0;
        Debug.LogError("Start");

        if (PlayerPrefs.GetInt("IsBiddingPluginInitialized") == 0) {
            foreach (var item in Data.BiddingComments) {
                Bid20Import.set_template(item.Key, item.Value);
            }

            Debug.LogError(Marshal.PtrToStringAnsi(Bid20Import.get_template(113)));

//        Bid20Import.f_eval("5 78 G 78 H 78 H K");
//
//        Bid20Import.setup_macros(15, 12, 21, 18, 3);
//        var result = Bid20Import.macro_verify();

            Bid20Import.macro_init(0);

            Bid20Import.macro("@undefine(/MACROFCM\\)", 0);
            Bid20Import.macro("@define(MACROFCM,FIVE CARD MAJOR OPENER)", 0);
            Bid20Import.macro("@undefine(/MACROACES\\)", 0);
            Bid20Import.macro("@define(MACROACES,!ROMAN KEY CARD BLACKWOOD)", 0);
            Bid20Import.macro("@undefine(/_NTMIN\\)", 0);
            Bid20Import.macro("@define(_NTMIN,15)", 0);
            Bid20Import.macro("@undefine(/_NT_MAX\\)", 0);
            Bid20Import.macro("@define(_NT_MAX,17)", 0);
            Bid20Import.macro("@undefine(/_NT_OPP_MIN\\)", 0);
            Bid20Import.macro("@define(_NT_OPP_MIN,12)", 0);
            Bid20Import.macro("@undefine(/_NT_OPP_MAX\\)", 0);
            Bid20Import.macro("@define(_NT_OPP_MAX,15)", 0);
            Bid20Import.macro("@undefine(/_NT_HIOPP_MIN\\)", 0);
            Bid20Import.macro("@define(_NT_HIOPP_MIN,18)", 0);
            Bid20Import.macro("@undefine(/_NT_HIOPP_MAX\\)", 0);
            Bid20Import.macro("@define(_NT_HIOPP_MAX,19)", 0);
            Bid20Import.macro("@undefine(/_TNTMIN\\)", 0);
            Bid20Import.macro("@define(_TNTMIN,20)", 0);
            Bid20Import.macro("@undefine(/_TNTMAX\\)", 0);
            Bid20Import.macro("@define(_TNTMAX,21)", 0);
            Bid20Import.macro("@define(bforth,#F$3 $1 $2)", 0);

            Bid20Import.macro("@define(_NT_SLAM,/@arith(33,-,_NTMIN)\\)", 0);
            Bid20Import.macro("@define(_NT_SLAM_PLUS,/@arith(32,-,_NTMIN)\\)", 0);
            Bid20Import.macro("@define(_NT_GSLAM,/@arith(37,-,_NTMIN)\\)", 0);
            Bid20Import.macro("@define(_NT_GSLAM_PLUS,/@arith(36,-,_NTMIN)\\)", 0);
            Bid20Import.macro("@define(_NT_GAME,/ @arith(26, -, _NTMIN)\\)", 0);

            //@define(@dr2,/ @define(/ BOTTOM\,$1)@define(/ TOP\,$2)\)
            //@define(@dr,/ @define(/ MYBOTTOM\,$1)@define(/ MYTOP\,$2)\)
            //@define(@setvars1,/$1 90G\)
            Bid20Import.macro("@define(@setvars2,/$1 90G $2 92G\\)", 0);
            Bid20Import.macro("@define(@setvars2,/$1 90G $2 92G\\)", 1);
            Bid20Import.macro("@define(@shortness,/#/F\\@setvars2($1,$2) 32 O M 98 G\\)", 0);
            Bid20Import.macro("@define(@shortness,/#/F\\@setvars2($1,$2) 32 O M 98 G\\)", 1);
            Bid20Import.macro("@define(@in_out1,/#/F\\@setvars2($1,$2) 23 O\\)", 0);
            Bid20Import.macro("@define(@in_out1,/#/F\\@setvars2($1,$2) 23 O\\)", 1);
            Bid20Import.macro("@define(@in_out3,/#/F\\@setvars3($1,$2,$3) 25 O\\)", 0);
            Bid20Import.macro("@define(@in_out3,/#/F\\@setvars3($1,$2,$3) 25 O\\)", 1);
            Bid20Import.macro("@define(@in_out2,/#/F\\@setvars3($1,$2,$3) 24 O\\)", 0);
            Bid20Import.macro("@define(@in_out2,/#/F\\@setvars3($1,$2,$3) 24 O\\)", 1);
            //@define(@in_long1,/#/F\@setvars1($1) 29 O\)
            Bid20Import.macro("@define(@in_long2,/#/F\\@setvars2($1,$2) 30 O\\)", 0);
            Bid20Import.macro("@define(@in_long2,/#/F\\@setvars2($1,$2) 30 O\\)", 1);
            Bid20Import.macro("@define(@setvars3,/$1 90G $2 92G $3 94G\\)", 1);
            Bid20Import.macro("@define(@setvars3,/$1 90G $2 92G $3 94G\\)", 0);
            Bid20Import.macro("@define(@od,/#/F\\@setvars3($1,$2,$3) 33 O\\)", 0);
            Bid20Import.macro("@define(@od,/#/F\\@setvars3($1,$2,$3) 33 O\\)", 1);

            Bid20Import.macro("@define(_NT_SUBMIN,/~@arith(_NTMIN,-,1)=\\)", 0);
            Bid20Import.macro("@define(__NT_MAX,/(~_NTMIN>&~@arith(_NTMIN,+,_R1)<)\\)", 0);
            Bid20Import.macro("@define(_TNT_SUBMIN,/~@arith(_TNTMIN,-,1)=\\)", 0);
            Bid20Import.macro("@define(__TNT_MAX,/(~_TNTMIN>&~@arith(_TNTMIN,+,_R4)<)\\)", 0);
            Bid20Import.macro("@define(__NT_HIOPP_MAX,/(~_NT_HIOPP_MIN>&~@arith(_TNTMIN,+,_R4)<)\\)", 0);
            Bid20Import.macro("@define(__NT_OPP_MAX,/(~@arith(_NT_OPP_MAX,-,3)>&~@arith(_NT_OPP_MAX,+,1)<)\\)", 0);
            Bid20Import.macro("@define(_TNT_GAME,/@arith(26,-,_TNTMIN)\\)", 0);
            Bid20Import.macro("@define(_TNT_INVITE,/@arith(32,-,_TNTMIN)\\)", 0);
            Bid20Import.macro("@define(_TNT_SLAM,/@arith(33,-,_TNTMIN)\\)", 0);
            Bid20Import.macro("@define(__TNT_SLAM,/(~@arith(32,-,_TNTMIN)>&~@arith(37,-,_TNTMIN)<)\\)", 0);
            Bid20Import.macro("@define(_TNT_GSLAM,/@arith(37,-,_TNTMIN)\\)", 0);
            Bid20Import.macro("@define(__TNT_GSLAM,/~@arith(36,-,_TNTMIN)>\\)", 0);
            Bid20Import.macro("@define(_NT_OPP_GAME,/@arith(26,-,_NT_OPP_MIN)\\)", 0);
            Bid20Import.macro("@define(__NT_OPP_SLAM,/(~@arith(32,-,_NT_OPP_MIN)>&~@arith(37,-,_NT_OPP_MIN)<)\\)", 0);
            Bid20Import.macro("@define(__NT_OPP_GSLAM,/~@arith(36,-,_NT_OPP_MIN)>\\)", 0);
            Bid20Import.macro("@define(_NT_OPP_INVITE,/@arith(26,-,_NT_OPP_MAX)\\)", 0);
            Bid20Import.macro("@define(_NT_OPP_SLAM,/@arith(33,-,_NT_OPP_MIN)\\)", 0);
            Bid20Import.macro("@define(_NT_OPP_INVITE_SLAM,/@arith(32,-,_NT_OPP_MIN)\\)", 0);
            Bid20Import.macro("@define(_NT_OPP_GSLAM,/@arith(37,-,_NT_OPP_MIN)\\)", 0);
            Bid20Import.macro("@define(_NT_HIOPP_GAME,/@arith(26,-,_NT_HIOPP_MIN)\\)", 0);
            Bid20Import.macro("@define(_NT_HIOPP_SLAM,/@arith(33,-,_NT_HIOPP_MIN)\\)", 0);
            Bid20Import.macro("@define(_NT_HIOPP_INVITE_SLAM,/@arith(32,-,_NT_HIOPP_MIN)\\)", 0);
            Bid20Import.macro("@define(__NT_HIOPP_GAME,/(~@arith(25,-,_NT_HIOPP_MIN)>&~@arith(33,-,_NT_HIOPP_MIN)<)\\)",
                0);
            Bid20Import.macro("@define(__NT_HIOPP_SLAM,/(~@arith(32,-,_NT_HIOPP_MIN)>&~@arith(37,-,_NT_HIOPP_MIN)<)\\)",
                0);
            Bid20Import.macro("@define(__NT_HIOPP_GSLAM,/~@arith(36,-,_NT_HIOPP_MIN)>\\)", 0);
            Bid20Import.macro("@define(_NT_HIOPP_GSLAM,/@arith(37,-,_NT_HIOPP_MIN)\\)", 0);

            Bid20Import.macro("@define(_NT_SUBMIN,/~@arith(_NTMIN,-,1)=\\)", 1);
            Bid20Import.macro("@define(__NT_MAX,/(~_NTMIN>&~@arith(_NTMIN,+,_R1)<)\\)", 1);
            Bid20Import.macro("@define(_TNT_SUBMIN,/~@arith(_TNTMIN,-,1)=\\)", 1);
            Bid20Import.macro("@define(__TNT_MAX,/(~_TNTMIN>&~@arith(_TNTMIN,+,_R4)<)\\)", 1);
            Bid20Import.macro("@define(__NT_HIOPP_MAX,/(~_NT_HIOPP_MIN>&~@arith(_TNTMIN,+,_R4)<)\\)", 1);
            Bid20Import.macro("@define(__NT_OPP_MAX,/(~@arith(_NT_OPP_MAX,-,3)>&~@arith(_NT_OPP_MAX,+,1)<)\\)", 1);
            Bid20Import.macro("@define(_TNT_GAME,/@arith(26,-,_TNTMIN)\\)", 1);
            Bid20Import.macro("@define(_TNT_INVITE,/@arith(32,-,_TNTMIN)\\)", 1);
            Bid20Import.macro("@define(_TNT_SLAM,/@arith(33,-,_TNTMIN)\\)", 1);
            Bid20Import.macro("@define(__TNT_SLAM,/(~@arith(32,-,_TNTMIN)>&~@arith(37,-,_TNTMIN)<)\\)", 1);
            Bid20Import.macro("@define(_TNT_GSLAM,/@arith(37,-,_TNTMIN)\\)", 1);
            Bid20Import.macro("@define(__TNT_GSLAM,/~@arith(36,-,_TNTMIN)>\\)", 1);
            Bid20Import.macro("@define(_NT_OPP_GAME,/@arith(26,-,_NT_OPP_MIN)\\)", 1);
            Bid20Import.macro("@define(__NT_OPP_SLAM,/(~@arith(32,-,_NT_OPP_MIN)>&~@arith(37,-,_NT_OPP_MIN)<)\\)", 1);
            Bid20Import.macro("@define(__NT_OPP_GSLAM,/~@arith(36,-,_NT_OPP_MIN)>\\)", 1);
            Bid20Import.macro("@define(_NT_OPP_INVITE,/@arith(26,-,_NT_OPP_MAX)\\)", 1);
            Bid20Import.macro("@define(_NT_OPP_SLAM,/@arith(33,-,_NT_OPP_MIN)\\)", 1);
            Bid20Import.macro("@define(_NT_OPP_INVITE_SLAM,/@arith(32,-,_NT_OPP_MIN)\\)", 1);
            Bid20Import.macro("@define(_NT_OPP_GSLAM,/@arith(37,-,_NT_OPP_MIN)\\)", 1);
            Bid20Import.macro("@define(_NT_HIOPP_GAME,/@arith(26,-,_NT_HIOPP_MIN)\\)", 1);
            Bid20Import.macro("@define(_NT_HIOPP_SLAM,/@arith(33,-,_NT_HIOPP_MIN)\\)", 1);
            Bid20Import.macro("@define(_NT_HIOPP_INVITE_SLAM,/@arith(32,-,_NT_HIOPP_MIN)\\)", 1);
            Bid20Import.macro("@define(__NT_HIOPP_GAME,/(~@arith(25,-,_NT_HIOPP_MIN)>&~@arith(33,-,_NT_HIOPP_MIN)<)\\)",
                1);
            Bid20Import.macro("@define(__NT_HIOPP_SLAM,/(~@arith(32,-,_NT_HIOPP_MIN)>&~@arith(37,-,_NT_HIOPP_MIN)<)\\)",
                1);
            Bid20Import.macro("@define(__NT_HIOPP_GSLAM,/~@arith(36,-,_NT_HIOPP_MIN)>\\)", 1);
            Bid20Import.macro("@define(_NT_HIOPP_GSLAM,/@arith(37,-,_NT_HIOPP_MIN)\\)", 1);

            Bid20Import.macro("@undefine(/MACROFCM\\)", 1);
            Bid20Import.macro("@define(MACROFCM,FIVE CARD MAJOR OPENER)", 1);
            Bid20Import.macro("@undefine(/MACROACES\\)", 1);
            Bid20Import.macro("@define(MACROACES,!ROMAN KEY CARD BLACKWOOD)", 1);
            Bid20Import.macro("@undefine(/_NTMIN\\)", 1);
            Bid20Import.macro("@define(_NTMIN,15)", 1);
            Bid20Import.macro("@undefine(/_NT_MAX\\)", 1);
            Bid20Import.macro("@define(_NT_MAX,17)", 1);
            Bid20Import.macro("@undefine(/_NT_OPP_MIN\\)", 1);
            Bid20Import.macro("@define(_NT_OPP_MIN,12)", 1);
            Bid20Import.macro("@undefine(/_NT_OPP_MAX\\)", 1);
            Bid20Import.macro("@define(_NT_OPP_MAX,15)", 1);
            Bid20Import.macro("@undefine(/_NT_HIOPP_MIN\\)", 1);
            Bid20Import.macro("@define(_NT_HIOPP_MIN,18)", 1);
            Bid20Import.macro("@undefine(/_NT_HIOPP_MAX\\)", 1);
            Bid20Import.macro("@define(_NT_HIOPP_MAX,19)", 1);
            Bid20Import.macro("@undefine(/_TNTMIN\\)", 1);
            Bid20Import.macro("@define(_TNTMIN,20)", 1);
            Bid20Import.macro("@undefine(/_TNTMAX\\)", 1);
            Bid20Import.macro("@define(_TNTMAX,21)", 1);
            Bid20Import.macro("@define(bforth,#F$3 $1 $2)", 1);
            Bid20Import.macro("@define(_NT_SLAM,/@arith(33,-,_NTMIN)\\)", 1);
            Bid20Import.macro("@define(_NT_SLAM_PLUS,/@arith(32,-,_NTMIN)\\)", 1);
            Bid20Import.macro("@define(_NT_GSLAM,/@arith(37,-,_NTMIN)\\)", 1);
            Bid20Import.macro("@define(_NT_GSLAM_PLUS,/@arith(36,-,_NTMIN)\\)", 1);
            Bid20Import.macro("@define(_NT_GAME,/ @arith(26, -, _NTMIN)\\)", 1);

            Bid20Import.initialize_matchtree();

//            int ruleCount = 0;
//            foreach (var rule in GameConfig.Rules) {
//                bool isMatch = Regex.IsMatch(rule, "done", RegexOptions.IgnoreCase);
//
//                if (ruleCount == 0) {
//                    Bid20Import.set_first_rule(rule);
//                    ruleCount++;
//                }
//                else if (isMatch) {
//                    Debug.LogError("finishing up");
//                    Bid20Import.finish_rules();
//                    Debug.LogError("rules all finished");
//                }
//                else {
//                    //if (rule_count < 5) Debug.LogError("doing another rule");
//                    Bid20Import.set_next_rule(rule);
//                    ruleCount++;
//                }
//            }

            for (int i = 0; i < Data.Rules.Count; i++) {
                if (i == 0) {
                    Bid20Import.set_first_rule(Data.Rules[i]);
                }
                else if (i == Data.Rules.Count - 1) {
                    Debug.LogError("finishing up");
                    Bid20Import.finish_rules();
                    Debug.LogError("rules all finished");
                }
                else {
                    //if (rule_count < 5) Debug.LogError("doing another rule");
                    Bid20Import.set_next_rule(Data.Rules[i]);
                }
            }

            Bid20Import.UpdateSystem();
//        Bid20Import.clearbids();

            foreach (var item in Data.BiddingConventions) {
                Bid20Import.c_set(item.Key, 0, item.Value);
                Bid20Import.c_set(item.Key, 1, item.Value);
            }

            Bid20Import.set_table(0);
            Bid20Import.c_lock(0, 0);
            Bid20Import.c_lock(0, 1);

            Bid20Import.set_evaluation_system(2);

            Bid20Import.my_evaluate_sequence("1N");
            string comment = Marshal.PtrToStringAnsi(Bid20Import.get_best_comment(0));
            Debug.LogError(comment);

            Debug.LogError(Marshal.PtrToStringAnsi(Bid20Import.get_line_info(99)));

            PlayerPrefs.SetInt("IsBiddingPluginInitialized", 1);
        }

        SetPlayerCards(_pbnGame.text);
        Bid20Import.set_dealer(_dealer.value);
        Bid20Import.set_vul(0, 0);
        Bid20Import.set_vul(1, 0);

        if (_vulnerability.value == 0) {
            vul = 0;
        }
        else if (_vulnerability.value == 1) {
            Bid20Import.set_vul(0, 1);
            vul = 1;
        }
        else if (_vulnerability.value == 2) {
            Bid20Import.set_vul(1, 1);
            vul = 2;
        }
        else if (_vulnerability.value == 3) {
            Bid20Import.set_vul(0, 1);
            Bid20Import.set_vul(1, 1);
            vul = 3;
        }

        int slot = 0;

        for (int i = 0; i < _northPlayerCards.Count; i++) {
            Bid20Import.set_deck(slot, (int) _northPlayerCards[i].Suit * 13 + _northPlayerCards[i].Value);
            slot++;
        }

        for (int i = 0; i < _eastPlayerCards.Count; i++) {
            Bid20Import.set_deck(slot, (int) _eastPlayerCards[i].Suit * 13 + _eastPlayerCards[i].Value);
            slot++;
        }

        for (int i = 0; i < _southPlayerCards.Count; i++) {
            Bid20Import.set_deck(slot, (int) _southPlayerCards[i].Suit * 13 + _southPlayerCards[i].Value);
            slot++;
        }

        for (int i = 0; i < _westPlayerCards.Count; i++) {
            Bid20Import.set_deck(slot, (int) _westPlayerCards[i].Suit * 13 + _westPlayerCards[i].Value);
            slot++;
        }

        for (int i = 0; i < 4; i++) {
            string front_str = Marshal.PtrToStringAnsi(Bid20Import.get_description2(i, vul));
            string full_str = front_str + ":M" + "0C" + "0D" + "0H" + "0S";
            Bid20Import.set_description(i, full_str);
        }

        Bid20Import.set_seq("");
        Bid20Import.mybreak(1);
        Bid20Import.clearbids();
        Bid20Import.clear_clues();

        string current_seq = "";

        int index = 0;

//        Uncomment for testing 7NT opening bid
//        Bid20Import.set_seq("7N");

        while (!current_seq.Contains(":P:P:P")) {
//            Uncomment for testing weird bid
//            if (index == 4) {
//                Bid20Import.set_seq(Marshal.PtrToStringAnsi(Bid20Import.get_seq()) + ":4H");
//                Debug.LogError(Marshal.PtrToStringAnsi(Bid20Import.get_seq()));
//            }

            Debug.LogError("calling mybid");
            Bid20Import.mybid();
            //Debug.LogError("setting seq to P:P:P:P");
            //Bid20Import.set_seq("P:P:P:P");
            Debug.LogError("call get_seq");
            IntPtr seq = Bid20Import.get_seq();
            Debug.LogError("printing seq");
            //Debug.LogError("marshalling to current_seq");
            current_seq = Marshal.PtrToStringAnsi(seq);
//            Debug.LogError(current_seq);
            Bid20Import.my_evaluate_sequence(current_seq);
            string comment = Marshal.PtrToStringAnsi(Bid20Import.get_best_comment(0));
            string line_info = Marshal.PtrToStringAnsi(Bid20Import.get_line_info(1));
            Debug.LogError(current_seq + " " + comment + " Line info: " + line_info);
            //Debug.LogError(current_seq);
            index++;
        }

        Debug.LogError("Finished.");
    }

    private void SetPlayerCards(string pbn) {
        string declarer = pbn.Substring(0, 1);
        pbn = pbn.Remove(0, 2);
        string[] cards = pbn.Split(' ');

        for (int i = 0; i < cards.Length; i++) {
            switch (declarer) {
                case "N":
                    _northPlayerCards = GetPlayerCards(cards[i]);
                    declarer = "E";
                    break;
                case "E":
                    _eastPlayerCards = GetPlayerCards(cards[i]);
                    declarer = "S";
                    break;
                case "S":
                    _southPlayerCards = GetPlayerCards(cards[i]);
                    declarer = "W";
                    break;
                case "W":
                    _westPlayerCards = GetPlayerCards(cards[i]);
                    declarer = "N";
                    break;
            }
        }
    }

    private List<Card> GetPlayerCards(string eachPlayerPartofPBN) {
        List<Card> cards = new List<Card>();
        string[] suits = eachPlayerPartofPBN.Split('.');

        for (int i = 0; i < suits[0].Length; i++) {
            cards.Add(new Card {
                Suit = Suit.Spades,
                Value = GetCardValueFromPBNString(suits[0].Substring(i, 1))
            });
        }

        for (int i = 0; i < suits[1].Length; i++) {
            cards.Add(new Card {
                Suit = Suit.Hearts,
                Value = GetCardValueFromPBNString(suits[1].Substring(i, 1))
            });
        }

        for (int i = 0; i < suits[2].Length; i++) {
            cards.Add(new Card {
                Suit = Suit.Diamonds,
                Value = GetCardValueFromPBNString(suits[2].Substring(i, 1))
            });
        }

        for (int i = 0; i < suits[3].Length; i++) {
            cards.Add(new Card {
                Suit = Suit.Clubs,
                Value = GetCardValueFromPBNString(suits[3].Substring(i, 1))
            });
        }

        return cards;
    }

    private int GetCardValueFromPBNString(string character) {
        switch (character) {
            case "2":
                return 0;
            case "3":
                return 1;
            case "4":
                return 2;
            case "5":
                return 3;
            case "6":
                return 4;
            case "7":
                return 5;
            case "8":
                return 6;
            case "9":
                return 7;
            case "T":
                return 8;
            case "J":
                return 9;
            case "Q":
                return 10;
            case "K":
                return 11;
            case "A":
                return 12;
        }

        return 0;
    }

    private void Start() {
        // _pbnGame.text = "E:AT5.AJT.A632.KJ7 Q763.KQ9.KQJ94.T 942.87653..98653 KJ8.42.T875.AQ42";
        _pbnGame.text = "N:52.985.T543.AQ84 AJ9873.J42.J.J72 KT64.3.98762.953 Q.AKQT76.AKQ.KT6";
        _northPlayerCards = new List<Card>();
        _eastPlayerCards = new List<Card>();
        _southPlayerCards = new List<Card>();
        _westPlayerCards = new List<Card>();

        _bidButton.onClick.AddListener(Bid);

        _dealer.ClearOptions();
        _dealer.AddOptions(new List<string> {
            "North",
            "East",
            "South",
            "West"
        });

        _vulnerability.ClearOptions();
        _vulnerability.AddOptions(new List<string> {
            "None",
            "NS",
            "EW",
            "Both"
        });
    }
}