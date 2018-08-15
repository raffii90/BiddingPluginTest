using System;
using System.Runtime.InteropServices;

public class Bid20Import {
    [DllImport("_bid20")]
    public static extern void set_template(int number, string comment);

    [DllImport("_bid20")]
    public static extern int f_eval(string str);

    [DllImport("_bid20")]
    public static extern int set_first_rule(string first_line);

    [DllImport("_bid20")]
    public static extern int set_next_rule(string line);

    [DllImport("_bid20")]
    public static extern int finish_rules();

    [DllImport("_bid20")]
    public static extern IntPtr get_template(int number);

    [DllImport("_bid20")]
    public static extern void setup_macros(int min, int oppmin, int tntmin, int hioppmin, int dir);

    [DllImport("_bid20")]
    public static extern int macro_verify();

    [DllImport("_bid20")]
    public static extern int macro_init(int number);

    [DllImport("_bid20")]
    public static extern void initialize_matchtree();

    [DllImport("_bid20")]
    public static extern void read_rules();

    [DllImport("_bid20")]
    public static extern void clearbids();

    [DllImport("_bid20")]
    public static extern void set_dealer(int dealer);

    [DllImport("_bid20")]
    public static extern void c_set(string name, int number, int setting);

    [DllImport("_bid20")]
    public static extern void set_evaluation_system(int number);

    [DllImport("_bid20")]
    public static extern void set_table(int number);

    [DllImport("_bid20")]
    public static extern void c_lock(int table, int dir);

    [DllImport("_bid20")]
    public static extern void macro(string str, int dir);

    [DllImport("_bid20")]
    public static extern void UpdateSystem();

    [DllImport("_bid20")]
    public static extern IntPtr get_best_comment(int number);

    [DllImport("_bid20")]
    public static extern void my_evaluate_sequence(string sequence);

    [DllImport("_bid20")]
    public static extern IntPtr get_description2(int dir, int vul);

    [DllImport("_bid20")]
    public static extern IntPtr get_seq();

    [DllImport("_bid20")]
    public static extern IntPtr get_line_info(int number);

    [DllImport("_bid20")]
    public static extern void set_deck(int card, int value);

    [DllImport("_bid20")]
    public static extern void set_vul(int arg1, int arg2);

    [DllImport("_bid20")]
    public static extern void set_description(int dir, string str);

    [DllImport("_bid20")]
    public static extern void set_seq(string str);

    [DllImport("_bid20")]
    public static extern int mybid();

    [DllImport("_bid20")]
    public static extern void mybreak(int id);

    [DllImport("_bid20")]
    public static extern void clear_clues();
}