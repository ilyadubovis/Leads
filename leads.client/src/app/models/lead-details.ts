import { Lead } from "./lead";

export interface LeadDetails extends Lead {
  canCommunicateViaText: boolean;
  canCommunicateViaEmail: boolean;
  email?: string;
  streetAddress?: string;
  city?: string;
  state?: string;
  comment?: string;
}
