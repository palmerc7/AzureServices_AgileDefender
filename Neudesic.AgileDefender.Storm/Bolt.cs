using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using Microsoft.SCP;
using Microsoft.SCP.Rpc.Generated;

namespace Neudesic.AgileDefender.Storm
{
    public class Bolt : ISCPBolt
    {
        private int count;
        private Context ctx;

        public Bolt(Context ctx)
        {
            this.ctx = ctx;

            Dictionary<string, List<Type>> inputSchema = new Dictionary<string, List<Type>>();
            inputSchema.Add("default", new List<Type>() { typeof(int) });
            this.ctx.DeclareComponentSchema(new ComponentStreamSchema(inputSchema, null));
        }

        public static Bolt Get(Context ctx, Dictionary<string, Object> parms)
        {
            return new Bolt(ctx);
        }

        public void Execute(SCPTuple tuple)
        {
            count += (int)tuple.GetValue(0);
            Context.Logger.Info("counter", count);
        }
    }
}